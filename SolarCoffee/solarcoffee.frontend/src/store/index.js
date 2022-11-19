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
                   
        };
    },
    mutations: rootMutations,
    actions: rootActions,
    getters: rootGetters,
});

export default store;