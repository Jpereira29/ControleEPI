<template>
  <v-container>
    <DialogNewCategory :data.sync="categories" />

    <v-row align="center" justify="center">
      <v-col cols="auto">
        <ButtonCategory v-if="categories.length" :categories.sync="categories" :products.sync="products" />
      </v-col>
    </v-row>
    <Product v-if="products.length" v-for="product in products" :data="product" />

  </v-container>
</template>

<script>
import DialogNewCategory from '~/components/DialogNewCategory.vue';
import ButtonCategory from '~/components/ButtonCategory.vue';
import Product from '~/components/Product.vue';
import { getCategories } from '../axios/api.ts'

export default {
  name: "IndexPage",
  data() {
    return {
      categories: [],
      products: []
    };
  },
  mounted() {
    getCategories()
      .then(response => {
        this.categories = response.data
        console.log(response.data)
      })
      .catch(error => {
        console.error(error);
      });
  },
  components: { DialogNewCategory, ButtonCategory, Product }
}
</script>
