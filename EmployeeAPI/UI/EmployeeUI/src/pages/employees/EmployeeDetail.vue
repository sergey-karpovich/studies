<template>
    <div>
        <section>
            <base-card>
            <h3>{{ selectedEmployee.firstName }}</h3>
            <h4>{{ selectedEmployee.lastName }}</h4>
            <h4>{{ selectedEmployee.hireDate }}</h4>
            <h4>{{ selectedEmployee.title }}</h4>
            </base-card>
        </section>
    </div>
</template>

<script>
export default {
    props:['id'],
    data(){
        return {
            selectedEmployee: null,

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

    created(){
        const emp = this.selectedEmployee = this.$store.getters['employee/employees']
        this.selectedEmployee = this.search(this.id, emp);
    },
}
</script>