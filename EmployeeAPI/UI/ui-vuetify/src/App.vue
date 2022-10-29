<template>
  <v-app>   
      <the-header></the-header>
     
    <v-main class="ma-12 pa-12">
      <v-snackbar
            v-model="snackbar"
            :timeout="timeout"
            top
            >
            {{ textSnackbar }}

            <template v-slot:action="{ attrs }">
                <v-btn
                color="blue"
                text
                v-bind="attrs"
                @click="snackbar = false"
                >
                Close
                </v-btn>
            </template>
      </v-snackbar>

      <router-view @showSnackbar="showSnackbar"></router-view>
    </v-main>
  </v-app>
</template>

<script>
import TheHeader from './components/layout/TheHeader.vue';

export default {
  name: 'App',

  components: {
    TheHeader,
  },

  data() {
    return {

      textSnackbar: '',
      snackbar: false,
      timeout: this.$store.getters.timeout
    }
  },
  methods:{
    showSnackbar(text){
      this.snackbar=true;
      this.textSnackbar=text;
    }
  }
};
</script>
