<template>
    <div class="text-center">
      <v-menu v-for="category in categories" :key="category.categoryId">
        <template v-slot:activator="{ on }">
          <v-btn v-on="on"  style="margin: 5px;" @click="getProducts(category.categoryId)">
            {{ category.name }}
          </v-btn>
        </template>
        <v-list>
          <v-list-item class="blue--text text--lighten-1" @click="setModalEpi(category.categoryId)">
            <v-list-item-title>Adicionar EPI</v-list-item-title>
          </v-list-item>
        </v-list>
      </v-menu>
    </div>
  </template>
  

<script>
import { getProductsPerCategory } from '../axios/api.ts'

export default {
    props: ["categories", "products", "modalEpi", "categoryId"],
    methods: {
        getProducts(id) {
            getProductsPerCategory(id)
                .then(response => {
                    this.$emit('update:products', response.data);
                })
                .catch(error => {
                    console.error(error);
                });
        },
        setModalEpi(categoryId) {
          this.$emit('update:modalEpi', true);
          this.$emit('update:categoryId', categoryId);
        }
    }
}
</script>