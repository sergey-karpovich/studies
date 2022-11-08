import counterMutations from './mutations.js';
import counterActions from './actions.js';
import counterGetters from './getters.js';

export default {
    namespaced: true,
    state(){
        return{ 
            requests: [],
             
        }
    },
    mutations: counterMutations,
    actions: counterActions,
    getters: counterGetters,
};