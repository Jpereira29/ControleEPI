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
                <v-text-field label="Nome*" required v-model="initialName" :value="initialName"></v-text-field>
              </v-col>
              <v-col cols="6">
                <v-text-field label="Valor*" required type="number" step="0.01"
                  v-model.number="initialPrice" :value="initialPrice"></v-text-field>
              </v-col>
              <v-col cols="12">
                <v-text-field label="Descrição*" required v-model="initialDescription" :value="initialDescription"></v-text-field>
              </v-col>
              <v-col cols="12">
                <v-text-field label="Imagem URL*" required v-model="initialImageUrl" :value="initialImageUrl"></v-text-field>
              </v-col>
            </v-row>
          </v-container>
        </v-card-text>
        <v-card-actions>
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
import { createProduct, updateProduct } from '../axios/api.ts'

export default {
  props: ["modalEpi", "categoryId", "update", "product"],
  data: () => ({
    dialog: true,
    name: '',
    description: '',
    imageUrl: '',
    price: 0,
  }),
  methods: {
    saveData() {
      const data = {
        name: this.name,
        description: this.description,
        price: this.price,
        imageUrl: this.imageUrl,
        categoryId: parseInt(this.categoryId)
      };

      createProduct(data).then(response => {
        this.$emit('update:modalEpi', false);
      })
        .catch(error => {
          console.error(error.response);
        })
    },

    updateData() {
      const data = {
        productId: this.product.productId,
        name: this.initialName,
        description: this.description,
        price: this.price,
        imageUrl: this.imageUrl,
        categoryId: parseInt(this.product.categoryId)
      };

      updateProduct(data).then(response => {
        this.$emit('update:modalEpi', false);
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
    initialName: {
      get() {
        return this.update ? this.product.name : '';
      },
      set(value) {
        this.name = value;
      }
    },
    initialPrice: {
      get() {
        return this.update ? this.product.price : 0;
      },
      set(value) {
        this.price = parseFloat(value);
      }
    },
    initialDescription: {
      get() {
        return this.update ? this.product.description : '';
      },
      set(value) {
        this.description = value;
      }
    },
    initialImageUrl: {
      get() {
        return this.update ? this.product.imageUrl : '';
      },
      set(value) {
        this.imageUrl = value;
      }
    },
  },

}
</script>
