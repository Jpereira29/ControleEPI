<template>
  <v-row justify="center">
    <v-dialog v-model="dialog" persistent width="1024">
      <v-card>
        <v-card-title>
          <span class="text-h5">EPI</span>
        </v-card-title>
        <v-card-text>
          <v-container>
            <v-row>
              <v-col cols="6">
                <v-text-field label="Nome*" required v-model="name" :value="name" :rules="nameRules"></v-text-field>
              </v-col>
              <v-col cols="6">
                <v-text-field label="Valor*" required type="number" step="0.01" v-model.number="price"
                  :value="price"></v-text-field>
              </v-col>
              <v-col cols="12">
                <v-text-field label="Descrição*" required v-model="description" :value="description" :rules="descriptionRules"></v-text-field>
              </v-col>
              <v-col cols="12">
                <v-text-field label="Imagem URL*" required v-model="imageUrl" :value="imageUrl" :rules="imageUrlRules"></v-text-field>
              </v-col>
            </v-row>
          </v-container>
        </v-card-text>
        <v-card-actions>
          <v-btn v-if="product" color="red" variant="text" @click="deleteData()">
            Deletar
          </v-btn>
          <v-spacer></v-spacer>
          <v-btn color="blue-darken-1" variant="text" @click="closeModal">
            Fechar
          </v-btn>
          <v-btn color="blue-darken-1" variant="text" @click="update ? updateData() : saveData()">
            Salvar
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-row>
</template>

<script>
import { createProduct, updateProduct, deleteProduct, getProductsPerCategory } from '../axios/api.ts'

export default {
  props: ["modalEpi", "categoryId", "update", "product", "products"],

  data() {
    return {
      dialog: true,
      name: this.product ? this.product.name : '',
      description: this.product ? this.product.description : '',
      imageUrl: this.product ? this.product.imageUrl : '',
      price: this.product ? this.product.price : 0,
      productId: this.product ? this.product.productId : null,
      nameRules: [
        v => !!v || 'Nome é requerido!',
        v => (v && v.length >= 3) || 'O nome deve ser conter no mínimo 3 caracteres.',
      ],
      descriptionRules: [
        v => !!v || 'Descrição é requerido!',
        v => (v && v.length >= 10 && v.length <= 300) || 'Descrição deve ser conter entre 10 e 300 caracteres.',
      ],
      imageUrlRules: [
        v => !!v || 'La URL de la imagen es requerida',
        v => /^https?:\/\/\S+$/.test(v) || 'Inserir uma URL de imagem válida',
      ],
    };
  },
  methods: {
    saveData() {
      const data = {
        name: this.name,
        description: this.description,
        price: this.price,
        imageUrl: this.imageUrl,
        categoryId: parseInt(this.categoryId),
      };

      createProduct(data).then(response => {
        getProductsPerCategory(response.data.categoryId)
          .then(response => {
            this.$emit('update:products', response.data);
            this.$emit('update:modalEpi', false);
          })
          .catch(error => {
            console.error(error);
          });
      })
    },

    updateData() {
      const data = {
        name: this.name,
        description: this.description,
        price: this.price,
        imageUrl: this.imageUrl,
        categoryId: parseInt(this.categoryId),
        productId: this.productId
      };

      updateProduct(data).then(response => {
        this.$emit('update:modalEpi', false);
        this.$emit('update:product', response.data);
      })
        .catch(error => {
          console.error(error.response);
        })
    },

    deleteData() {
      deleteProduct(this.productId).then(response => {
        this.$emit('update:modalEpi', false);
        this.$router.push('/');
      })
        .catch(error => {
          console.error(error.response);
        })
    },

    closeModal() {
      this.dialog = false
      this.$emit('update:modalEpi', false);
    }
  },
  computed: {
  },

}
</script>
