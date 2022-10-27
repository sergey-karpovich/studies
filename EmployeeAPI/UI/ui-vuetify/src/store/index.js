import Vue from 'vue'
import Vuex from 'vuex'

import rootMutations from './mutations.js';
import rootActions from './actions.js';
import rootGetters from './getters.js';

import employeeModule from './modules/employee/index.js';
import projectsModule from './modules/projects/index.js';
import workTimeModule from './modules/workTime/index.js';
// import authModule from './modules/auth/index.js';

Vue.use(Vuex)

const store=new Vuex.Store({
    modules:{
        employee: employeeModule,
        projects: projectsModule,
        workTime: workTimeModule,
        // auth: authModule,
    },    
    state(){
        return{
            API_URL: 'https://localhost:7075/api',
            PHOTO_URL: 'https://localhost:7075/photos/',
        };
    },
    mutations: rootMutations,
    actions: rootActions,
    getters: rootGetters,
});

export default store;