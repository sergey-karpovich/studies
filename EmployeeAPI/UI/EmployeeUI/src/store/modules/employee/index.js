import counterMutations from './mutations.js';
import counterActions from './actions.js';
import counterGetters from './getters.js';

export default {
    namespaced: true,
    state(){
        return{
            lastFetch: null,
            employees: [
                {
                    EmployeeId: '1',
                    firstName: 'Maximilian',
                    lastName: 'Schwarzmuller',
                    hireDate: '01.01.2020',
                    title: 
                        "I'm Maximilian and I've worked as a freelance web developer for years.",
                },
                {
                    EmployeeId: '1',
                    firstName: 'Sergey',
                    lastName: 'Karpovich',
                    hireDate: '01.01.2020',
                    title: 
                        "I'm Sergey and I want to work as a  web developer.",
                }
            ]
        }
    },
    mutations: counterMutations,
    actions: counterActions,
    getters: counterGetters,
};
