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
    <div class="d-flex align-center flex-column" v-if="product">
        <v-card width="400">
            <div class="parent-div">
                <v-img :src="product.imageUrl" height="100px" :class="['product-image', 'float-right']" cover></v-img>
            </div>

            <v-card-item>
                <v-card-title>{{ product.name }}</v-card-title>

                <v-card-subtitle>R$ {{ product.price }}</v-card-subtitle>
            </v-card-item>

            <v-card-text>
                {{ product.description }}
            </v-card-text>
        </v-card>
    </div>
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