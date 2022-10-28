<template>
    <v-container>
        <v-snackbar v-model="snackbar" :timeout="4000" top color="success">
            <span>Awesome! You added a new project.</span>
            <v-btn color="success lighten-1" @click="snackbar=false">Close</v-btn>
        </v-snackbar>
        <v-layout row>
            <base-dialog :show="!!error" title="An error occurred!" @close="handleError">
                <p>{{ error }}</p>
            </base-dialog>
        </v-layout>
        <v-layout row justify-center>
            <ProjectForm @projectAdded="projectAdded"></ProjectForm>
        </v-layout>

        <v-layout row justify-center> 
            <v-card sm12 md6 class="mx-1" min-width="400" max-width="400"            
            v-for="project in selectedProject" :key="project.ProjectId"> 
                <v-layout column v-if="!edit">
                    <div class="text-left" >

                        <v-chip >
                            Selected Project
                        </v-chip>
                    </div>                   
                    <v-flex xs12 md6 ma-2>
                        <div class="caption grey--text">Project name</div>
                        <div>{{ project.ProjectName }}</div>
                    </v-flex>
                    <v-flex xs12 md6 ma-2>
                        <div class="caption grey--text">Project budget</div>
                        <div>{{ project.Budjet }}$</div>
                    </v-flex>
                    <v-flex xs12 md6 ma-2>
                        <div class="caption grey--text">Date of adoption</div>
                        <div>{{ formatDate(project.DateOfAdoption) }}</div>
                    </v-flex>
                    <v-flex xs12 md6 ma-2>
                        <div class="caption grey--text">Deadline</div>
                        <div>By {{ formatDate(project.Deadline) }}</div>
                    </v-flex>
                    <v-flex xs12 md6 ma-2>
                        <div class="caption grey--text">Description</div>
                        <div>{{ project.Description }}</div>
                    </v-flex>                                  
                    <v-expansion-panels>
                        <v-expansion-panel >
                            <v-expansion-panel-header>
                                Employees
                            </v-expansion-panel-header>
                            <v-expansion-panel-content v-for="(employee,i) in project.Employees" :key="i">
                                <v-avatar left>
                                    <v-img :src="PhotoURL + employee.photoPath"></v-img>
                                </v-avatar>                                
                                    {{ employee.firstName +' '+employee.lastName}}
                            </v-expansion-panel-content>
                        </v-expansion-panel>
                    </v-expansion-panels>                    
                </v-layout>
                
                <v-layout v-else>
                    <ProjectEmployeeForm 
                    :id="selectedProject[0].ProjectId"
                    @closeEdit="edit=!edit"
                    ></ProjectEmployeeForm>
                </v-layout>

                

                <v-divider></v-divider>

                <v-card-actions v-if="!edit">
                    <v-btn color="primary" @click="edit=!edit">
                        Edit
                    </v-btn>
                    <v-btn color="error" @click="deleteProject">
                        delete
                    </v-btn>
                </v-card-actions>

            </v-card>

            <v-card sm12 md6 class="mx-1" min-width="400">
                <div v-if="isLoading">
                    <base-spinner></base-spinner>
                </div>
                <v-list v-else-if="hasProject">
                    <v-list-item-group v-model="model" mandatory color="indigo">

                        <v-layout row mb-1 mr-2>
                            <v-subheader>
                                <v-tooltip top>
                                    <template v-slot:activator="{ on, attrs }">
                                        <v-btn v-bind="attrs" small v-on="on" @click="sortBy('title')">
                                            <v-icon left>expand_more</v-icon>
                                            <span class="caption text-lowercase">Project name</span>
                                        </v-btn>
                                    </template>
                                    <span>Sort projects by project name</span>
                                </v-tooltip>
                            </v-subheader>
                            <v-spacer></v-spacer>
                            <v-subheader>
                                <v-tooltip top>
                                    <template v-slot:activator="{ on, attrs }">
                                        <v-btn v-bind="attrs" small v-on="on" @click="sortBy('title')">
                                            <v-icon left>expand_more</v-icon>
                                            <span class="caption text-lowercase">Deadline</span>
                                        </v-btn>
                                    </template>
                                    <span>Sort projects by project deadline</span>
                                </v-tooltip>
                            </v-subheader>
                        </v-layout>
                        <v-divider></v-divider>
                        <v-list-item v-for="(project) in projects" :key="project.ProjectId">
                            <v-list-item-content>
                                <v-list-item-title v-text="project.ProjectName"></v-list-item-title>
                            </v-list-item-content>
                            <v-spacer></v-spacer>
                            <v-list-item-content>
                                <v-list-item-title v-text="formatDate(project.Deadline)"></v-list-item-title>
                            </v-list-item-content>
                        </v-list-item>
                    </v-list-item-group>
                </v-list>
                <v-list v-else>
                    Projects not found
                </v-list>
            </v-card>


        </v-layout>
    </v-container>
</template>

<script>
import ProjectForm from '@/components/projects/ProjectForm.vue'
import ProjectEmployeeForm from '@/components/projects/ProjectEmployeeForm.vue'
export default {
    components: {
        ProjectForm,
        ProjectEmployeeForm,
    },
    data () 
    {
        return {
            edit: false,
        isLoading: false,
        error: null,
        snackbar: false,
        selectedProject: [{
            ProjectId: 57,
            ProjectName: 'some name',
            Budjet: 0,
            DateOfAdoption: '01.01.2020',
            Deadline: '01.01.2020',
            Description: 'some description',
            Employees: '',
        }],        
        
        model: null,       
        PhotoURL: this.$store.state.PHOTO_URL,
        }
    },
    computed: {
        projects() {            
            return this.$store.getters['projects/projects']
        },
        hasProject() {
            return !this.isLoading && this.projects.length > 0;
        },       
    },    
    watch: {
        model() {
            this.$store.commit('projects/selectProject', this.model);
            this.selectedProject = [(this.$store.getters['projects/projectByNumber'])]
        },        
    },
    methods: {
        handleError() {
            this.error = null;
        },
        async loadProjects() {
            this.isLoading = true;
            try {
                await this.$store.dispatch('projects/loadProjects');
                await this.$store.dispatch('employee/loadEmployees');
            } catch (error) {
                this.error = error.message || 'Something went wrong!';
            }
            this.isLoading = false
        },
        dateIsValid(date) {
        return !Number.isNaN(new Date(date).getTime());
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
        projectAdded(){
            this.snackbar=true;
        },
        async deleteProject(){
            this.isLoading = true;
            if (confirm("Delete project?")){
                try{
                    console.log(this.selectedProject[0].ProjectId)
                    await  this.$store.dispatch('projects/deleteProject', this.selectedProject[0].ProjectId);
                } catch (error){
                    this.error = error.message || 'Something went wrong!';
                }
            }
            this.isLoading=false
        },
    },
    created() {
        this.loadProjects();        
    }
}
</script>