<template>
    <v-dialog max-width="600px" v-model="dialog" persistent>
        <template v-slot:activator="{on, attrs}">
            <v-btn               
            class="success"
            v-bind="attrs"
            v-on="on">
                Add new project
            </v-btn>
        </template>
        <v-card >

            <v-card-text >
                <v-form class="px-3" ref="form">
                    <v-text-field label="Project Name"
                    v-model="ProjectName" 
                    prepend-icon="drive_file_rename_outline" 
                    :rules="inputRules.name"
                    >
                    </v-text-field>

                    <v-text-field
                    label="Budget"
                    v-model.number="Budget"
                    prepend-icon="paid"
                    type="number">                        
                    </v-text-field>

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
                            :rules="inputRules.date">                            
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
                            :rules="inputRules.date">                            
                            </v-text-field>
                        </template>
                        <v-date-picker v-model="Deadline"
                        @input="datePicker2=false"></v-date-picker>
                    </v-menu>

                    <v-textarea 
                    outlined                 
                    label="Description"
                    v-model="Description"
                    prepend-icon="edit"    
                    >
                    </v-textarea>

                    <v-btn class="success mx-2 mt-3"
                    @click="submit"
                    :loading="loading">
                        Add project
                    </v-btn>
                    <v-btn class="warning mx-2 mt-3"
                    @click="dialog = false">
                        Cancel
                    </v-btn>
                </v-form>            
            </v-card-text>
        </v-card>
    </v-dialog>
</template>

<script>
export default {
    emits:['projectAdded'],
    data(){
        return {
            ProjectName:'',
            Budget: null,
            DateOfAdoption: '',
            Deadline: '',
            Description: '',
            ProjectsEmployees: null,

            inputRules:{
                name:[v => !!v || 'Name is required',
                    v => (v && v.length > 3) || 'Name must be more than 3 characters',
                    v => (v && v.length <= 20) || 'Name must be less than 20 characters',],
                date:[
                    v=>!!v||'Date is required'
                ]
            },
            dialog: false,
            loading: false,
            datePicker1: false,
            datePicker2: false,
            error: null,
        }
    },
    methods:{
        async submit(){
            if(this.$refs.form.validate()){
                this.loading=true;
                const project={
                    ProjectName: this.ProjectName,
                    Budjet: this.Budget,
                    DateOfAdoption: this.DateOfAdoption,
                    Deadline: this.Deadline,
                    Description: this.Description,
                    ProjectsEmployees: this.ProjectsEmployees,
                }
                try{
                    await this.$store.dispatch('projects/registerProject', project);
                    this.$emit('projectAdded',"Awesome! You added a new project.");                    
                } catch(error){
                    this.error=error.message || 'Something went wrong!';
                }
                this.dialog = false;
                this.loading=false;
            }
        }
    }
}
</script>