<template>
   <v-card
    max-width="375"
    class="mx-auto"
  >
    <v-img
      :src="PhotoPath"
      height="300px"
      dark
    >
      <v-row class="fill-height">
        <v-card-title>
          <v-btn
            dark
            icon
            router to="/employee"
          >
            <v-icon>mdi-chevron-left</v-icon>
          </v-btn>

          <v-spacer></v-spacer>

          <v-btn
            dark
            icon
            class="mr-4"
            router :to="'/employee/edit/'+selectedEmployee.employeeId"
          >
            <v-icon>mdi-pencil</v-icon>
          </v-btn>

          <v-btn
            dark
            icon
          >
            <v-icon>mdi-dots-vertical</v-icon>
          </v-btn>
        </v-card-title>

        <v-spacer></v-spacer>

      </v-row>
    </v-img>
    
    <v-list two-line>
      <v-card-title class="black--text pl-12 pt-1">
        <div class="text-h4 pl-1 pt-1">
          {{ fullName }}
        </div>
      </v-card-title>

      <v-list-item>
        <v-list-item-icon>
          <v-icon color="indigo">
            mdi-phone
          </v-icon>
        </v-list-item-icon>

        <v-list-item-content>
          <v-list-item-title>{{ selectedEmployee.phoneNumber }}</v-list-item-title>
          <v-list-item-subtitle>Phone number</v-list-item-subtitle>
        </v-list-item-content>

        <v-list-item-icon>
          <v-icon>mdi-message-text</v-icon>
        </v-list-item-icon>
      </v-list-item>

      <v-list-item>
        <v-list-item-action><span class="material-icons">
          description
          </span>
        </v-list-item-action>

        <v-list-item-content>
          <v-list-item-title>{{ selectedEmployee.description }}</v-list-item-title>
        </v-list-item-content>
         
      </v-list-item>

      <v-divider inset></v-divider>

      <v-list-item>
        
        <v-list-item-action><span class="material-icons">
          attach_money
          </span>
        </v-list-item-action>

        <v-list-item-content>
          <v-list-item-title>{{ selectedEmployee.rate }}</v-list-item-title>
          <v-list-item-subtitle>Personal rate</v-list-item-subtitle>
        </v-list-item-content>
      </v-list-item>

      <v-list-item>
        <v-list-item-action><span class="material-icons">
        cake
        </span></v-list-item-action>

        <v-list-item-content>
          <v-list-item-title>{{ formatDate(selectedEmployee.birthDate)}}</v-list-item-title>
          <v-list-item-subtitle>Birth Date</v-list-item-subtitle>
        </v-list-item-content>
      </v-list-item>

      <v-list-item>
        <v-list-item-action><span class="material-icons">
        handshake
        </span></v-list-item-action>
        
        <v-list-item-content>
          <v-list-item-title>{{ formatDate(selectedEmployee.hireDate)}}</v-list-item-title>
          <v-list-item-subtitle>Hire Date</v-list-item-subtitle>
        </v-list-item-content>
      </v-list-item>
      <v-list-item>
      <v-list-item-action>
        <span class="material-icons">
        area_chart
        </span>
      </v-list-item-action>
      <v-list-item-content>
        <v-list-item-title>{{ selectedEmployee.areas}}</v-list-item-title>
        <v-list-item-subtitle>Areas</v-list-item-subtitle>
      </v-list-item-content>
      
        </v-list-item>

      <v-divider inset></v-divider>
<!--
      <v-list-item>
        <v-list-item-icon>
          <v-icon color="indigo">
            mdi-map-marker
          </v-icon>
        </v-list-item-icon>

         <v-list-item-content>
          <v-list-item-title>ADDRESS</v-list-item-title>
          <v-list-item-subtitle>ADDRESS</v-list-item-subtitle>
        </v-list-item-content> 
      </v-list-item>-->

    </v-list>
  </v-card>
</template>

<script>
export default {
    props:['id'],
    data(){
        return {
            selectedEmployee: null,
            PhotoPath: this.$store.state.PHOTO_URL
        }
    },
    computed: {
        fullName(){
            return this.selectedEmployee.firstName+' '+this.selectedEmployee.lastName;
        },
    },
    methods:{
         search(key, inputArray)  {
            for (let i=0; i < inputArray.length; i++) {
                if (inputArray[i].employeeId == key) {
                    //console.log(inputArray[i]);
                    return inputArray[i];

                }
            }
            return null
        },
        formatDate (date) {
            let d = new Date(date);
            let month = (d.getMonth() + 1).toString();
            let day = d.getDate().toString();
            let year = d.getFullYear();
            if (month.length < 2) {
                month = '0' + month;
            }
            if (day.length < 2) {
                day = '0' + day;
            }
            return [day, month, year].join('.');
        },
    },

    beforeMount(){
      const emp = this.$store.getters['employee/employees']
      this.selectedEmployee = this.search(this.id, emp);
      this.PhotoPath+=this.selectedEmployee.photoPath?this.selectedEmployee.photoPath:'anonymous.png';
      // console.log(this.PhotoPath);
    },
}
</script>