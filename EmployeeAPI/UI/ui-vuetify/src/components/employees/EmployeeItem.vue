<template>
  <v-card
    class="mx-auto"
    max-width="344"
    outlined
  >
    <v-list-item three-line>
      <v-list-item-content>
        <div class="text-overline mb-1">
          {{ firstName }}
        </div>
        <v-list-item-title class="text-h5 mb-1">
          {{ lastName }}
        </v-list-item-title>
        <v-list-item-subtitle>{{ description }}</v-list-item-subtitle>
      </v-list-item-content>

      <v-list-item-avatar
        tile
        size="80"
        color="grey"
      >
      <img class="image-employee" :src="PhotoPath+photoName" alt="photo" 
        width="200" height="200" /></v-list-item-avatar>
    </v-list-item>

    <v-card-actions>
      <v-btn
        outlined
        rounded
        text
        router :to="employeeEditLink"
      >
        Edit
      </v-btn>
      <v-btn
        outlined
        rounded
        text
        @click="deleteEmployee"
      >
      Delete
      </v-btn>
      <v-btn
        outlined
        rounded
        text
        router :to="employeeDetailsLink"
      >
      View Details
      </v-btn>
    </v-card-actions>
  </v-card>
</template>

<script>
export default {
  emits:['deleteEmployee'],
  data(){
    return {
      PhotoPath: this.$store.state.PHOTO_URL,
      photoName: this.PhotoFileName?this.PhotoFileName:'anonymous.png',
    }
  },
  props: ['id', 'firstName', 'lastName',  'description','rate','areas','birthDate','hireDate','phoneNumber','PhotoFileName']      ,
  computed: {
      fullName(){
          return this.firstName + ' ' + this.lastName;
      },        
      employeeDetailsLink(){
          return this.$route.path + '/' + this.id; 
      },
      employeeEditLink(){
        return this.$route.path + '/edit/' + this.id; 
      }
  },
  methods:{
    deleteEmployee(){
      if (confirm("Delete employee?")) {
        this.$emit('deleteEmployee',this.id)        
      }
    }
  }, 
}
</script>

<style scoped>
li {
  margin: 1rem 0;
  border: 1px solid #424242;
  border-radius: 12px;
  padding: 1rem;
}

h3 {
  font-size: 1.5rem;
}

h3,
h4 {
  margin: 0.5rem 0;
}

div {
  margin: 0.5rem 0;
}

.actions {
  display: flex;
  justify-content: flex-end;
}
 
.flex-row{
  display: flex;
  
  justify-content:space-between;
  
}
</style>