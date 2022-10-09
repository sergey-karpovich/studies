import { createStore } from 'vuex';

import rootMutations from './mutations.js';
import rootActions from './actions.js';
import rootGetters from './getters.js';

import employeeModule from './modules/employee/index.js';
// import projectsModule from './modules/projects/index.js';
// import authModule from './modules/auth/index.js';


 const store=createStore({
    modules:{
        employee: employeeModule,
        // projects: projectsModule,
        // auth: authModule,
    },    
    state(){
        return{
            API_URL: 'https://localhost:7075/api',
        };
    },
    mutations: rootMutations,
    actions: rootActions,
    getters: rootGetters,
});

export default store;