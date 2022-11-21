import Vue from 'vue'
import Router from 'vue-router'

import InventoryVue from '@/views/InventoryVue.vue'
import CustomersVue from '@/views/CustomersVue.vue'
import OrdersVue from '@/views/OrdersVue.vue'
import CreateInvoice from '@/views/CreateInvoice.vue'

Vue.use(Router)

const routes =[
    {
        path: '/',
        name: 'home',
        component: InventoryVue
    },
    {
        path: '/inventory',
        name: 'inventoryVue',
        component: InventoryVue
    },
    {
        path: '/customers',
        name: 'customers',
        component: CustomersVue
    },
    {
        path: '/orders',
        name: 'orders',
        component: OrdersVue
    },
    {
        path: '/invoice/new',
        name: 'create-invoice',
        component: CreateInvoice
    },
]

export default new Router({
    mode: 'history',
    base: process.env.BASE_URL,
    routes
})