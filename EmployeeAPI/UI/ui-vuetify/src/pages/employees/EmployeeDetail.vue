<template>
   <v-card
    max-width="375"
    class="mx-auto"
  >
    <v-img
      :src="PhotoPath+selectedEmployee.PhotoPath"
      height="300px"
      dark
    >
      <v-row class="fill-height">
        <v-card-title>
          <v-btn
            dark
            icon
          >
            <v-icon>mdi-chevron-left</v-icon>
          </v-btn>

          <v-spacer></v-spacer>

          <v-btn
            dark
            icon
            class="mr-4"
            router :to="'/employee/edit/'+selectedEmployee.EmployeeId"
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

        <v-card-title class="black--text pl-12 pt-12">
          <div class="text-h4 pl-12 pt-12">
            {{ fullName }}
          </div>
        </v-card-title>
      </v-row>
    </v-img>

    <v-list two-line>
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
        <v-list-item-action></v-list-item-action>

        <v-list-item-content>
          <v-list-item-title>{{ selectedEmployee.description }}</v-list-item-title>
        </v-list-item-content>
         
      </v-list-item>

      <v-divider inset></v-divider>

      <v-list-item>
        <v-list-item-icon>
          <v-icon color="indigo">
            mdi-money
          </v-icon>
        </v-list-item-icon>

        <v-list-item-content>
          <v-list-item-title>{{ selectedEmployee.rate }}</v-list-item-title>
          <v-list-item-subtitle>Personal rate</v-list-item-subtitle>
        </v-list-item-content>
      </v-list-item>

      <v-list-item>
        <v-list-item-action></v-list-item-action>

        <v-list-item-content>
          <v-list-item-title>{{ selectedEmployee.birthDate}}</v-list-item-title>
          <v-list-item-subtitle>Birth Date</v-list-item-subtitle>
        </v-list-item-content>
      </v-list-item>

      <v-list-item>
        <v-list-item-action></v-list-item-action>

        <v-list-item-content>
          <v-list-item-title>{{ selectedEmployee.hireDate}}</v-list-item-title>
          <v-list-item-subtitle>Hire Date</v-list-item-subtitle>
        </v-list-item-content>
      </v-list-item>
        <v-list-group
          :value="true"
          no-action
          sub-group
        >
            <template v-slot:activator>
                <v-list-item-content>
                <v-list-item-title>Areas</v-list-item-title>
                </v-list-item-content>
            </template>
            <v-list-item
            v-for="area in selectedEmployee.areas"
            :key="area"
            link>
                <v-list-item-title v-text="area"></v-list-item-title>
            </v-list-item>
        </v-list-group>

      <v-divider inset></v-divider>

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
      </v-list-item>
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
                if (inputArray[i].EmployeeId == key) {
                    console.log(inputArray[i]);
                    return inputArray[i];

                }
            }
            return null
        }
    },

    beforeMount(){
        
        const emp = this.selectedEmployee = this.$store.getters['employee/employees']
        this.selectedEmployee = this.search(this.id, emp);
    },
}
</script>