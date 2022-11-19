import Vue from 'vue'
import Router from 'vue-router'

import Inventory from '@/views/Inventory.vue'

Vue.use(Router)

const routes =[
    {
        path: '/',
        name: 'home',
        component: Inventory
    },
    {
        path: '/inventory',
        name: 'inventory',
        component: Inventory
    },
]

export default new Router({
    mode: 'history',
    base: process.env.BASE_URL,
    routes
})