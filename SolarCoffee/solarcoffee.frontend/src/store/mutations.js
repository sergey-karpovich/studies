export default {   
    getInventory(state, inventory){
        state.inventory=inventory;
    },
    getCustomers(state, customers){
        state.customers=customers;
    },
    getOrders(state, orders){
        state.orders = orders;
    }

}