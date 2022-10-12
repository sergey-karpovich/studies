<template>    
    <nav>
      <v-toolbar >
        <v-btn depressed text @click="drawer=!drawer" >
          <span class="material-icons">
            list
          </span>
        </v-btn>
        
        <v-toolbar-title class="text-uppercase grey--text">
          <span class="font-weight-light">Employee</span>
          <span>Manager</span>
        </v-toolbar-title>
        <v-spacer></v-spacer>
        <v-btn v-if="!isLoggedIn" >
          <span>Log In</span>
          <span class="material-icons">
            login
            </span>
        </v-btn>
        <v-btn v-else >
          <span>Loh Out</span>              
            <span class="material-icons">
              logout
              </span>
        </v-btn>
      </v-toolbar>

      <v-navigation-drawer
        v-model="drawer"
        absolute
        temporary>
          <v-list dense>
            <v-list-item
            v-for="item in items"
            :key="item.title"
            router-link :to="item.link"
            >
            <v-list-item-icon>
              <span class="material-icons">{{ item.icon }}</span>               
            </v-list-item-icon>
            
            <v-list-item-content>
              <v-list-item-title>{{ item.title }}</v-list-item-title>
            </v-list-item-content>
          </v-list-item>
        </v-list>
      </v-navigation-drawer>

      
         
  </nav>
      
</template>

<script>
export default {
  data(){
    return {
      drawer: false,
      logged: false,
      items: [
        {
          title: 'All Employee',
          link:'/employee',
          icon:'account_circle',
        },
        {
          title: 'Projects',
          link:'/projects',
          icon:'event',
        },

      ]
    }
  },
  computed: {
    isLoggedIn(){
      return this.$store.getters.isAuthenticated;
    }
  },
  methods: {
    logout(){
      this.$store.dispatch('logout');
      this.$router.replace('/coaches');
    }
  }
}
</script>

<style scoped>

    </style>