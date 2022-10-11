<template>
    <div>
        <base-dialog :show="!!error" title="An error occurred!" 
        @close="handleError">
        <p>{{ error }}</p>
        </base-dialog>
        <section>
            <!-- <base-card v-if="isCreating" title="Create New Employee" >   
                <employee-form @close="closeCreateForm" @submit-employee="submitEmployee"></employee-form>
            </base-card> -->
            <!-- <coach-filter @change-filter="setFilters"></coach-filter> -->
            <base-button link to="/employee/register">New Employee</base-button>
        </section>
        <section> 
            <base-card>
            <div class="controls">
                
            </div> 
            <div v-if="isLoading">
                <base-spinner></base-spinner>
            </div>
                <ul v-else-if="hasEmployees">
                    <employee-item v-for="employee in employees" 
                    :key="employee.EmployeeId" 
                    :id="employee.EmployeeId" 
                    :first-name="employee.firstName" 
                    :last-name="employee.lastName" 
                    :description="employee.description"
                    :rate="employee.rate"
                    :areas="employee.areas"
                    :birth-date="employee.birthDate"
                    :hire-date="employee.hireDate"
                    :home-phone="employee.homePhone"
                    :PhotoFileName="employee.photoPath"
                    @deleteEmployee="deleteEmployee"
                    ></employee-item>
                </ul>
                <h3 v-else>No employee found.</h3>
            </base-card>
        </section>     
    </div>
</template>

<script>
import EmployeeItem from '../../components/employees/EmployeeItem.vue';

export default {
    components: {
        EmployeeItem,
        
    },
    data(){
        return {
            isLoading: false,
            error: null,
            
        }
    },
    computed: {  
        employees(){
            return this.$store.getters['employee/employees']
        } ,
        hasEmployees(){
            return !this.isLoading && this.employees.length>0;
        },
        
    },
    methods: {
        async loadEmployee(){
            this.isLoading = true;
            try{
                await this.$store.dispatch('employee/loadEmployees');
            } catch (error){
                this.error = error.message || 'Something went wrong!';
            }
            this.isLoading=false
        },
        
        handleError() {
            this.error = null;
        },
       
        async deleteEmployee(id){
            this.isLoading = true;
            try{
                await this.$store.dispatch('employee/deleteEmployee',id);
            } catch (error){
                this.error = error.message || 'Something went wrong!';
            }
            this.isLoading=false
        }
    },
    created(){
        this.loadEmployee();
    }
}
</script>
 
<style scoped>
ul {
    list-style: none;
    margin: 0;
    padding: 0;
}

.controls {
    display: flex;
    justify-content: space-between;
}
</style>
