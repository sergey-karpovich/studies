<template>
    <div>
        <base-dialog :show="!!error" title="An error occurred!" @close="handleError">
        <p>{{ error }}</p>
        </base-dialog>
        <section>
            <coach-filter @change-filter="setFilters"></coach-filter>
        </section>
        <section> 
            <base-card>
            <div class="controls">
                
            </div> 
            <div v-if="isLoading">
                <base-spinner></base-spinner>
            </div>
                <ul v-else-if="hasEmployee">
                    <coach-item v-for="employee in employees" 
                    :key="employee.EmployeeId" 
                    :id="employee.EmployeeId" 
                    :first-name="employee.firstName" 
                    :last-name="employee.lastName" 
                    
                    ></coach-item>
                </ul>
                <h3 v-else>No employee found.</h3>
            </base-card>
        </section>     
    </div>
</template>

<script>
import EmployeeItem from './EmployeeItem.vue'


export default {
    components: {
        CoachItem,
        
    },
    data(){
        return {
            isLoading: false,
            error: null,
            
        }
    },
    computed: {  
    },
    methods: {
        
        async loadCoaches(refresh = false){
            this.isLoading = true;
            try{
                await this.$store.dispatch('coaches/loadCoaches', {forceRefresh: refresh});
            } catch (error){
                this.error=error.message || 'Something went wrong!';
            }
            this.isLoading = false;
        },
        handleError() {
            this.error = null;
        }
    },
    created(){
        this.loadCoaches();
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
