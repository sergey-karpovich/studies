<template>
    <div>
        <base-dialog :show="!!error" title="An error occurred!" 
        @close="handleError">
        <p>{{ error }}</p>
        </base-dialog>
        <section>
            <base-card v-if="isCreating" title="Create New Employee" 
                >   
                <employee-form @close="closeCreateForm"></employee-form>
            </base-card>
            <!-- <coach-filter @change-filter="setFilters"></coach-filter> -->
            <base-button @click="openForm">New Employee</base-button>
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
                    :hire-date="employee.hireDate"
                    :title="employee.title"
                    ></employee-item>
                </ul>
                <h3 v-else>No employee found.</h3>
            </base-card>
        </section>     
    </div>
</template>

<script>
import EmployeeItem from '../../components/employees/EmployeeItem.vue';
import EmployeeForm from '../../components/employees/EmployeeForm.vue';

export default {
    components: {
        EmployeeItem,
        EmployeeForm,
    },
    data(){
        return {
            isLoading: false,
            error: null,
            creating: false
        }
    },
    computed: {  
        employees(){
            return this.$store.getters['employee/employees']
        } ,
        hasEmployees(){
            return !this.isLoading && this.employees.length>0;
        },
        isCreating(){
            return this.creating
        } ,
    },
    methods: {
        async loadEmployee(){
            this.isLoading = true;
            try{
                await this.$store.dispatch('employee/loadEmployees')
            } catch (error){
                this.error = error.message || 'Something went wrong!';
            }
            this.isLoading=false
        },
        
        handleError() {
            this.error = null;
        },
        openForm(){
            console.log('openForm');
            this.creating=true;
        },
        closeCreateForm(){
            this.creating = false;
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
