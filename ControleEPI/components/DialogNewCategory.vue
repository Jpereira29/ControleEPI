<template>
  <v-row justify="center">
    <v-dialog v-model="dialog" persistent width="1024">
      <template v-slot:activator="{ props }">
        <v-btn color="primary" v-bind="props" @click="dialog = true"> Nova Categoria </v-btn>
      </template>
      <v-card>
        <v-card-title>
          <span class="text-h5">Categoria</span>
        </v-card-title>
        <v-card-text>
          <v-container>
            <v-row>
              <v-col cols="12">
                <v-text-field label="Nome*" required v-model="name"></v-text-field>
              </v-col>
            </v-row>
          </v-container>
        </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="blue-darken-1" variant="text" @click="dialog = false">
            Fechar
          </v-btn>
          <v-btn color="blue-darken-1" variant="text" @click="saveData">
            Salvar
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-row>
</template>

<script>
import axios from 'axios';
import { getCategories } from '../axios/api.ts'


export default {
  data: () => ({
    dialog: false,
    name: ''
  }),
  props: ["data"],
  methods: {
    async saveData() {
      const data = {
        name: this.name
      };
      try {
        const response = await axios.post('https://localhost:7188/api/Category', data);
        this.dialog = false;
        console.log(response.data);

        getCategories()
          .then(response => {
            this.$emit('update:data', response.data);
          })
          .catch(error => {
            console.error(error);
          });
      } catch (error) {
        console.error(error);
      }
    }
  }
}
</script>
