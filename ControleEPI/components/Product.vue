<template>
  <v-card class="mx-auto" max-width="344">
    <v-img :src="product.imageUrl" height="200px" cover></v-img>

    <v-card-title> {{ product.name }} </v-card-title>

    <v-card-subtitle> {{ product.price }} </v-card-subtitle>

    <v-card-actions>
      <v-btn color="orange-lighten-2" variant="text" @click="setModalEpi"> Editar </v-btn>

      <v-spacer></v-spacer>

      <v-btn @click="toggleShow">
        <template v-slot:default>
          <v-icon v-if="show">mdi-chevron-up</v-icon>
          <v-icon v-else>mdi-chevron-down</v-icon>
        </template>
      </v-btn>
    </v-card-actions>
    <v-expand-transition>
      <div v-show="show">
        <v-divider></v-divider>

        <v-card-text>
          {{ product.description }}
        </v-card-text>
      </div>
    </v-expand-transition>
  </v-card>
</template>

<script>
export default {
  data() {
    return {
      show: false,
    }
  },
  props: ['data', 'modalEpi'],
  computed: {
    product() {
      return this.data;
    },
  },
  methods: {
    setModalEpi() {
      this.$emit('update:modalEpi', true);
    },
    toggleShow() {
      this.show = !this.show;
    },
  }
}
</script>