<template>
<div>
    <h1 id="ordersTitle">
        Sales Orders
    </h1>
    <hr />
    <table id="sales-orders" class="table" v-if="orders.length">
        <thead>
            <tr>
                <th>CustomerId</th>
                <th>OrderId</th>
                <th>Order Total</th>
                <th>Order Status</th>
                <th>Mark Complete</th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="order in orders" :key="order.id">
                <td>
                    {{ order.customer.id }}
                </td>
                <td>
                    {{ order.id }}
                </td>
                <td>
                    {{ getTotal(order) | price }}
                </td>
                <td :class="{ green : order.isPaid, red : !order.isPaid}">
                    {{ getStatus(order.isPaid) }}
                </td>
                <td>
                    <div
                      v-if="!order.isPaid"
                      class="lni lni-checkmark-circle order-complete green"
                      @click="markComplete(order.id)"
                    ></div>
                </td>
            </tr>
        </tbody>
    </table>
</div>
</template>

<script>
export default 
{
    data()
    {
        return{
            orders: [],
            order:{
                id: 0,
                createdOn:"",
                updatedOn: "",
                customer: {},
                isPaid: false,
                salesOrderItems: [],
            }
        }
    },
    methods:
    {
        async initialize()
        {
            await this.$store.dispatch('getOrders');
            this.orders=this.$store.getters.orders;
        },
        getTotal(order)
        {
            return order.salesOrderItems
                .reduce((a, b) => a + (b['product']['price'] * b['quantity']), 0);
        },
        getStatus(isPaid)
        {
            return isPaid ? "Paid in Full" : "Unpaid";            
        },
        async markComplete(id)
        {
            await this.$store.dispatch('makeOrderComplete',id);
            await this.initialize();
        }
    },
    created()
    {
        this.initialize();
    }
}
</script>

<style scoped lang="scss">
@import "@/scss/global.scss";
.red
{
    font-weight: bold;
    color: $solar-red;
}
.green 
{
    font-weight: bold;
    color: $solar-green;
}
.inventory-actions
{
    display: flex;
    margin-bottom: 0.8rem;
}
.order-complete
{
    cursor: pointer;
}
</style>