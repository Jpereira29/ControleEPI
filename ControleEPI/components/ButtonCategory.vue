<template>
    <v-layout class="overflow-visible" style="height: 56px; left: 0;">
        <v-bottom-navigation v-model="value" color="primary">
            <v-btn v-for="category in categories" :key="category.categoryId" @click="getProducts(category.categoryId)">
                <v-icon>mdi-history</v-icon>
                {{ category.name }}
            </v-btn>
        </v-bottom-navigation>
    </v-layout>
</template>
<script>
import { getProductsPerCategory } from '../axios/api.ts'

export default {
    data: () => ({ value: 0 }),
    props: ["categories", "products"],
    methods: {
        getProducts(id) {
            getProductsPerCategory(id)
                .then(response => {
                    this.$emit('update:products', response.data);
                })
                .catch(error => {
                    console.error(error);
                });
        }
    }
}
</script>