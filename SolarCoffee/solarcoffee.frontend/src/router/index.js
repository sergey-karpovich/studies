import Vue from 'vue'
import Router from 'vue-router'

import InventoryVue from '@/views/InventoryVue.vue'

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
]

export default new Router({
    mode: 'history',
    base: process.env.BASE_URL,
    routes
})