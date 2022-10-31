import projectsMutations from './mutations.js';
import projectsActions from './actions.js';
import projectsGetters from './getters.js';

export default {
    namespaced: true,
    state(){
        return{ 
            projects: [],
             
        }
    },
    mutations: projectsMutations,
    actions: projectsActions,
    getters: projectsGetters,
};