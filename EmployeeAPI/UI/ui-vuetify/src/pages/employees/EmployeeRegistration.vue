<template>
    <section>       

        <base-dialog :show="!!error" title="An error occurred!" @close="handleError">
            <p>{{ error }}</p>
        </base-dialog>
        <base-spinner v-if="isLoaded"></base-spinner>
        <base-card>
            <h2>Register employee</h2>
            <employee-form 
                @close="closeCreateForm" 
                @submit-employee="submitEmployee"
                :id="id?id:null"
                ></employee-form>
        </base-card>
    </section>
</template>

<script>
import EmployeeForm from '@/components/employees/EmployeeForm.vue';

export default {
    props:['id'],

    components: {
        employeeForm: EmployeeForm,
    } ,
    data(){
        return {
            isLoaded: false,
            error: null,
            
        }
    },    
    methods: {
        async submitEmployee(employee){
             this.isLoaded=true;
            
            try{
                if(this.id){
                    await this.$store.dispatch('employee/updateEmployee', employee);
                    this.$router.replace('/employee');
                } else {
                    await this.$store.dispatch('employee/registerEmployee', employee);
                    this.$router.replace('/employee');
                }
           
            } catch (error){
                this.error=error.message || 'Something went wrong!';
            }
            
            this.isLoaded=false;
        },
        handleError(){
            this.error=null;
        },
        closeCreateForm(){
            this.$router.replace('/employee');
        }
    } ,
   
}
</script>

<style scoped>

</style>