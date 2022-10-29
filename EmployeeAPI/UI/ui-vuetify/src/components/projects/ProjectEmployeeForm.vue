<template>
  <v-card>
    <v-form>
      <v-container>
        <v-snackbar v-model="snackbar" :timeout="4000" top color="success">
            <span>Project updated successfully!</span>
            <v-btn color="success lighten-1" @click="snackbar=false">Close</v-btn>
        </v-snackbar>
            <v-row>
                <v-col cols="12" md="6">
                    <v-text-field v-model="ProjectName" 
                    :disabled="isUpdating" filled 
                    color="blue-grey lighten-2" label="Name">
                    </v-text-field>
                </v-col>
                <v-col cols="12" md="6">
                  <v-text-field v-model.number="Budjet" :disabled="isUpdating"
                  type="number" filled color="blue-grey lighten-2"
                  label="Budjet"></v-text-field>
                </v-col>

                <v-menu
                    v-model="datePicker1"                    
                    transition="scale-transition"
                    offset-y
                    min-width="auto">
                        <template v-slot:activator="{on, attrs}">
                            <v-text-field
                            v-model="DateOfAdoption"
                            prepend-icon="mdi-calendar"
                            v-bind="attrs"
                            v-on="on"
                            label="Date of Adoption"
                            >                            
                            </v-text-field>
                        </template>
                        <v-date-picker v-model="DateOfAdoption"
                        @input="datePicker1=false"></v-date-picker>
                    </v-menu>
                    <v-menu
                    v-model="datePicker2"                    
                    transition="scale-transition"
                    offset-y
                    min-width="auto">
                        <template v-slot:activator="{on, attrs}">
                            <v-text-field
                            v-model="Deadline"
                            prepend-icon="priority_high"
                            v-bind="attrs"
                            v-on="on"
                            label="Deadline"
                            >                            
                            </v-text-field>
                        </template>
                        <v-date-picker v-model="Deadline"
                        @input="datePicker2=false"></v-date-picker>
                    </v-menu>

                <v-col cols="12" >
                    <v-text-field v-model="Description" 
                    :disabled="isUpdating" filled 
                    color="blue-grey lighten-2" label="Description">
                    </v-text-field>
                </v-col>
                                
                <v-col cols="12">
                    <v-autocomplete 
                    v-model="Employees" 
                    :disabled="isUpdating" 
                    :items="allEmployees" 
                    filled 
                    chips 
                    color="blue-grey lighten-2" 
                    label="Assign employee" 
                    item-text="employeeId" 
                    item-value="employeeId" 
                    multiple>
                        <template v-slot:selection="data">
                            <v-chip v-bind="data.attrs" 
                            :input-value="data.selected" 
                            close 
                            @click="data.select"
                            @click:close="remove(data.item)">
                                <v-avatar left>
                                    <v-img :src="PhotoURL +data.item.photoPath"></v-img>
                                </v-avatar>
                                {{ data.item.firstName }}
                            </v-chip>
                        </template>
                        <template v-slot:item="data">
                            <template v-if="typeof data.item !== 'object'">
                                <v-list-item-content v-text="data.item"></v-list-item-content>
                            </template>
                            <template v-else>
                                <v-list-item-avatar>
                                    <img :src="PhotoURL +data.item.photoPath">
                                </v-list-item-avatar>
                                <v-list-item-content>
                                    <v-list-item-title v-html="data.item.firstName"></v-list-item-title>
                                    <v-list-item-subtitle v-html="data.item.lastName"></v-list-item-subtitle>
                                </v-list-item-content>
                            </template>
                        </template>
                    </v-autocomplete>
                </v-col> 
            </v-row>
        </v-container>
    </v-form>
    <v-card-actions>

      <v-btn       
        :loading="isUpdating"
        color="primary"
        depressed
        @click="updateProject"
      >
        <v-icon left>
          mdi-update
        </v-icon>
        Update Now
      </v-btn>
      <v-btn color="error" @click="cancel">
        Cancel
      </v-btn>
    </v-card-actions>
  </v-card>

</template>

<script>
export default {
    props:['id'],
    data () {      
      return {
        ProjectId: 57,
        ProjectName: 'some name',
        Budjet: 0,
        DateOfAdoption: '01.01.2020',
        Deadline: '01.01.2020',
        Description: 'some description',
        Employees: [],

        allEmployees:[],

        datePicker1: null,
        datePicker2: null,

        PhotoURL: this.$store.state.PHOTO_URL,
               
        isUpdating: false, 
        snackbar: false,    
          
      }
    },

    watch: {
      isUpdating (val) {
        if (val) {
          setTimeout(() => (this.isUpdating = false), 3000)
        }
      },
    },

    methods: {
      remove (item) {  
        const index = this.Employees.findIndex(e=>e.employeeId === item.employeeId)
        if (index >= 0) this.Employees.splice(index, 1)        
      },

      async updateProject(){
        this.isUpdating = true;
        const tempEmployees=[];
        for(const num in this.Employees){
          tempEmployees.push(this.allEmployees[num]);
        }
        const project = {
          ProjectId:  this.ProjectId,
          ProjectName: this.ProjectName,
          Budjet: this.Budjet,
          DateOfAdoption: this.DateOfAdoption,
          Deadline: this.Deadline,
          Description: this.Description,
          Employees:  tempEmployees,
        };
        const eids=[];
        for(let i=0; i<tempEmployees.length; i++)
        {
          eids.push(tempEmployees[i].employeeId);
        }
        const junction={
          id: project.ProjectId,
          eids: eids,
        };
        try{
          await this.$store.dispatch('projects/updateProject',project);
          await this.$store.dispatch('projects/addEmployeesById', junction);
          this.snackbar=true;          
        } catch(error){
          console.log(error.message);
        }
        this.isUpdating = false;
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
            return [year, month, day].join('-');
      },
      
      cancel(){
        this.$emit('closeEdit')
      }
    },    
    beforeMount(){
        if(this.id!=0){
            const project =  this.$store.getters['projects/projects']
            .find(p=>p.ProjectId==this.id);
            if(!project) return;
            this.ProjectId = project.ProjectId;
            this.ProjectName= project.ProjectName;
            this.Budjet= project.Budjet;
            this.DateOfAdoption= this.formatDate(project.DateOfAdoption);
            this.Deadline= this.formatDate(project.Deadline);
            this.Description= project.Description;
            this.Employees= project.Employees;
        } 
        this.allEmployees=this.$store.getters['employee/employees'];       
    }
}
</script>