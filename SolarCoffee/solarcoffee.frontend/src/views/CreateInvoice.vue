<template>
<div>
    <h1 id="invoiceTitle">
        Create Invoice
    </h1>
    <hr />

    <div class="invoice-step" v-if="invoiceStep ===1">
        <h2>Step 1: Select Customer</h2>
        <div v-if="customers.length" class="invoice-step-detail">
            <label for="customer">Customer</label>
            <select v-model="selectedCustomerId" class="invoiceCustomers" id="customer">
                <option disabled value="">Please select a Customer</option>
                <option v-for="c in customers" :value="c.id" :key="c.id">
                    {{ c.firstName+" "+c.lastName }}
                </option>
            </select>
        </div>
    </div>
    <div class="invoice-step" v-if="invoiceStep ===2">
    
    </div>
    <div class="invoice-step" v-if="invoiceStep ===3">
    
    </div>
</div>
</template>

<script>
export default {
    data(){
        return{
            invoiceStep: 1,
            invoice: {
                createdOn: new Date(),
                customerId: 0,
                lineItems: [],
                updatedOn: new Date(),
            },
            customers: [],
            selectedCustomerId: 0,
            inventory: [], 
            lineItems: [],
            newItem: {
                product:{},
                quantity: 0,
            }

        }
    },
    methods:{
        async initialization(){
            await this.$store.dispatch('getInventory');
            this.inventory=this.$store.getters.inventory;
            await this.$store.dispatch('getCustomers');
            this.customers=this.$store.getters.customers;
            await this.$store.dispatch('getOrders');
            this.lineItems=this.$store.getters.orders;
        },
    },
    async created(){
        await this.initialization();
    },
}
</script>

<style scoped lang="scss">

</style>