<template>
    <li>
      <div class="flex-row">
        <div >
          <h3>{{ fullName }}</h3>
          <h4>{{ description }}</h4>
          <h4>{{ rate }}</h4>
          <h4>{{ areas }}</h4>
        <h4>{{ birthDate }}</h4>
        <h4>{{ hireDate }}</h4>
        <h4>{{ homePhone }}</h4>
      </div>
      <div>
        <img class="image-employee" :src="PhotoPath+photoName" alt="photo" 
        width="200" height="200" />
      </div> 
      
    </div>
        <div class="actions">
            <base-button link :to="employeeDetailsLink">Edit</base-button>
            <base-button mode="attention" @click="deleteEmployee">Delete</base-button>
            <base-button link :to="employeeDetailsLink">View Details</base-button>
        </div>
    </li>
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
  props: ['id', 'firstName', 'lastName',  'description','rate','areas','birthDate','hireDate','homePhone','PhotoFileName']      ,
  computed: {
      fullName(){
          return this.firstName + ' ' + this.lastName;
      },        
      employeeDetailsLink(){
          return this.$route.path + '/' + this.id; 
      }
  },
  methods:{
    deleteEmployee(){
      if (confirm("Delete employee?")) {
        this.$emit('deleteEmployee',this.id)
      }
    }
  },
  created(){
    // console.log(this.PhotoFileName);
  }
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