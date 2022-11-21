<template>
<div>
    <h1 id="customersTitle">
        Manage Customers
    </h1>
    <hr />
    <div class="customer-actions">
        <solar-button @button:click="showNewCustomerModal">
            AddCustomer
        </solar-button>
    </div>
    <table id="customers" class="table">
        <tr>
            <th>Customer</th>
            <th>Address</th>
            <th>State</th>
            <th>Since</th>
            <th>Delete</th>
        </tr>
        <tr v-for="customer in customers" :key="customer.id">
            <td>
                {{ customer.firstName +" " +customer.lastName}}
            </td>
            <td>
                {{ customer.primaryAddress.addressLine1+" "
                +customer.primaryAddress.addressLine2 }}
            </td>
            <td>
                {{ customer.primaryAddress.state }}
            </td>
            <td>
                {{ customer.createdOn | humanizeDate}}
            </td>
            <td>
                <div 
                  class="lni lni-cross-circle customer-delete"
                  @click="deleteCustomer(customer.id)"
                  >                        
                </div>
            </td>
        </tr>
    </table>
    <new-customer-modal
        @close="closeModal"
        @save:customer="saveNewCustomer"
        v-if="isCustomerModalVisible"
    />
    
</div>
</template>


<script>
 import SolarButton from '@/components/SolarButton.vue';
import NewCustomerModal from '@/components/Models/NewCustomerModal.vue';

export default {
    components:{
        SolarButton,
        NewCustomerModal,        
    },
    data(){
        return{
            isCustomerModalVisible: false,
            customers: [],

        }
    },
    methods:{
        showNewCustomerModal(){
            this.isCustomerModalVisible=true;
        },
        async initialize(){
           await  this.$store.dispatch('getCustomers');
           this.customers=this.$store.getters.customers;
        },
        async deleteCustomer(id){
            await this.$store.dispatch('deleteCustomer',id);
            this.initialize();
        },
        closeModal(){
            this.isCustomerModalVisible=false;
        },
        async saveNewCustomer(customer){
            await this.$store.dispatch('addCustomer',customer);
            this.initialize();
            this.isCustomerModalVisible=false;
        },
    },
    created(){
        this.initialize();
    }

}
</script>

<style scoped lang="scss">
@import "@/scss/global.scss";

.customer-actions{
    display: flex;
    margin-bottom: 0.8rem;
}
.customer-delete{    
    cursor: pointer;
    font-weight: bold;
    font-size: 1.2rem;
    color: $solar-red;
}

div{
    margin-right: 0.8rem;
}

</style>