<template>
  <v-app>   
      <the-header></the-header>
     
    <v-main class="ma-12 pa-12">
      <router-view></router-view>
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

  data: () => ({
    //
  }),
};
</script>
