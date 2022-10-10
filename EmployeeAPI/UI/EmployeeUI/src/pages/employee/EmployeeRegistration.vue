<template>
    <section>
        <base-dialog :show="!!error" title="An error occurred!" @close="handleError">
            <p>{{ error }}</p>
        </base-dialog>
        <base-spinner v-if="isLoaded"></base-spinner>
        <base-card>
            <h2>Register as a coach now!</h2>
            <coach-form @submit-coach="submitCoach"></coach-form>
        </base-card>
    </section>
</template>

<script>
import CoachForm from '../../components/coaches/CoachForm.vue';

export default {
    components: {
        EmployeeForm,
    } ,
    data(){
        return {
            isLoaded: false,
            error: null,
        }
    },
    
    methods: {
        async submitCoach(coach){
            // console.log(coach);
            this.isLoaded=true;
            
            try{
                await this.$store.dispatch('coaches/registerCoach',coach);
                this.$router.replace('/coaches');
           
            } catch (error){
                this.error=error.message || 'Something went wrong!';
            }
            
            this.isLoaded=false;
        },
        handleError(){
            this.error=null;
        }
    } 
}
</script>

<style scoped>

</style>