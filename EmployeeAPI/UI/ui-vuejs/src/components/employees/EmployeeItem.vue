<template>
    <li>
      <div class="flex-row">
        <div >
          <h3>{{ fullName }}</h3>
          <h4><strong>Description: </strong>{{ description }}</h4>
          <h4>Rate: {{ rate }}</h4>
          <h4>Areas: {{ areas }}</h4>
        <h4>Birth Date: {{ birthDate }}</h4>
        <h4>Hire Date: {{ hireDate }}</h4>
        <h4>Phone Number: {{ phoneNumber }}</h4>
      </div>
      <div>
        <img class="image-employee" :src="PhotoPath+photoName" alt="photo" 
        width="200" height="200" />
      </div> 
      
    </div>
        <div class="actions">
            <base-button link :to="employeeEditLink"  >Edit</base-button>
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
  created(){
    // console.log(this.PhotoFileName);
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