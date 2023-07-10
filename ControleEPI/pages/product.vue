<template>
  <div>
    <Product v-if="product" :data.sync="product" :modalEpi.sync="modalEpi" />
    <DialogNewProduct v-if="modalEpi" :modalEpi.sync="modalEpi" 
      :categoryId.sync="product.categoryId" 
      :update.sync="update"
      :product.sync="product"
    />
  </div>
</template>

<script>
import Product from '~/components/Product.vue';
import DialogNewProduct from '~/components/DialogNewProduct.vue';
import { getProduct } from '../axios/api.ts'

export default {
  name: 'InspirePage',
  data() {
    return {
      product: null,
      modalEpi: false,
      update: true
    };
  },
  mounted() {
    getProduct(1)
      .then(response => {
        this.product = response.data
      })
      .catch(error => {
        console.error(error);
      });
  },
  components: { Product, DialogNewProduct }
}
</script>
