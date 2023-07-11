<style>
.parent-div {
    position: relative;
}

.product-image {
    border-radius: 50%;
    width: 100px;
    height: 100px;
    margin: 5px;
}

.float-right {
    float: right;
}
</style>
<template>
    <div class="d-flex align-center flex-column">
        <v-card width="400" style="margin: 5px;" @click="redirectToProductPage" v-if="product">
            <div class="parent-div">
                <v-img :src="product.imageUrl" height="100px" :class="['product-image', 'float-right']" cover></v-img>
            </div>

            <v-card-title>{{ product.name }}</v-card-title>
            <v-card-subtitle>R$ {{ product.price }}</v-card-subtitle>

            <v-card-text>
                {{ product.description }}
            </v-card-text>
        </v-card>
    </div>
</template>

<script>
export default {
    data() {
        return {
            show: false,
            product: this.data
        }
    },
    props: ['data'],
    methods: {
        redirectToProductPage() {
            const productId = this.product.productId;
            this.$router.push({ name: 'product', params: { id: productId } });
        }
    }
}
</script>