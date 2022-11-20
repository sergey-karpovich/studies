import Vue from 'vue'
import Vuex from 'vuex'

import rootMutations from './mutations.js';
import rootActions from './actions.js';
import rootGetters from './getters.js';

Vue.use(Vuex)

const store=new Vuex.Store({
    modules:{       
    },    
    state(){
        return{
            API_URL: process.env.VUE_APP_API_URL,
            //API_URL2: 'https://localhost:7087/api',
            inventory: [],
        };
    },
    mutations: rootMutations,
    actions: rootActions,
    getters: rootGetters,
});

export default store;