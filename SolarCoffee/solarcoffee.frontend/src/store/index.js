import Vue from 'vue'
import Vuex from 'vuex'

import rootMutations from './mutations.js';
import rootActions from './actions.js';
import rootGetters from './getters.js';
import pathify from 'vuex-pathify';
//import { make } from 'vuex-pathify';

pathify.options.mapping = 'simple';
pathify.options.deep = 2;

Vue.use(Vuex)

const store=new Vuex.Store({
    modules:{       
    },    
    state(){
        return{
            API_URL: process.env.VUE_APP_API_URL,
            //API_URL2: 'https://localhost:7087/api',
            inventory: [],
            customers:[],
            orders:[],
            snapshot: [],
        };
    },
    mutations: rootMutations,
    actions: rootActions,
    getters: rootGetters,
    plugin: [pathify.plugin],
});

export default store;