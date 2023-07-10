<template>
  <v-container>
    <DialogNewCategory :data.sync="categories" />
    <DialogNewProduct v-if="modalEpi" :modalEpi.sync="modalEpi" :categoryId.sync="categoryId" />

    <v-row align="center" justify="center">
      <v-col cols="auto">
        <ButtonCategory v-if="categories.length" :categories.sync="categories" :products.sync="products"
          :modalEpi.sync="modalEpi" :categoryId.sync="categoryId" />
      </v-col>
    </v-row>
    <ProductCard v-if="products.length" v-for="product in products" :data="product" />
  </v-container>
</template>

<script>
import DialogNewCategory from '~/components/DialogNewCategory.vue';
import ButtonCategory from '~/components/ButtonCategory.vue';
import ProductCard from '~/components/ProductCard.vue';
import DialogNewProduct from '~/components/DialogNewProduct.vue';

import { getCategories } from '../axios/api.ts'

export default {
  name: "IndexPage",
  data() {
    return {
      categories: [],
      products: [],
      modalEpi: false,
      categoryId: 0
    };
  },
  mounted() {
    getCategories()
      .then(response => {
        this.categories = response.data
      })
      .catch(error => {
        console.error(error);
      });
  },
  components: { DialogNewCategory, ButtonCategory, ProductCard, DialogNewProduct }
}
</script>
