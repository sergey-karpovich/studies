import counterMutations from './mutations.js';
import counterActions from './actions.js';
import counterGetters from './getters.js';

export default {
    namespaced: true,
    state(){
        return{
            lastFetch: null,
            coaches: [
                {
                    id: 'c1',
                    firstName: 'Maximilian',
                    lastName: 'Schwarzmuller',
                    areas: ['frontend', 'backend', 'career'],
                    description: 
                        "I'm Maximilian and I've worked as a freelance web developer for years.",
                    hourlyRate: 30,
                },
                {
                    id: 'c2',
                    firstName: 'Julie',
                    lastName: 'Jones',
                    areas: ['frontend', 'career'],
                    description: 
                        "I'm Julie and as a senior developer in a big tech company, I can help you.",
                    hourlyRate: 30,
                }
            ]
        }
    },
    mutations: counterMutations,
    actions: counterActions,
    getters: counterGetters,
};
