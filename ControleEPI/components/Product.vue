<template>
    <v-card
      class="mx-auto"
      max-width="344"
      style="margin: 10px;"
    >
      <v-img
        src="https://cdn.vuetifyjs.com/images/cards/sunshine.jpg"
        height="200px"
        cover
      ></v-img>
  
      <v-card-title>
        {{ product.name }}
      </v-card-title>
  
      <v-card-subtitle>
        1,000 miles of wonder
      </v-card-subtitle>
  
      <v-card-actions>
        <v-btn
          color="orange-lighten-2"
          variant="text"
        >
          Explore
        </v-btn>
  
        <v-spacer></v-spacer>
  
        <v-btn
          :icon="show ? 'mdi-chevron-up' : 'mdi-chevron-down'"
          @click="show = !show"
        ></v-btn>
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
  data: () => ({
    show: false,
  }),
  props: ['data'],
  computed: {
    product() {
      return this.data;
    },
  },
}
</script>