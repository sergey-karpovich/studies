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
                    phoneNumber: 1111111,
                    rate: 14,
                    birthDate: '01.01.2020',
                    hireDate: '01.01.2020',
                    description: 
                    "I'm Maximilian and I've worked as a freelance web developer for years.",
                    areas: ['frontend','backend'],
                },
                {
                    EmployeeId: '2',
                    firstName: 'Sergey',
                    lastName: 'Karpovich',
                    phoneNumber: 1111111,
                    birthDate: '01.01.2020',
                    hireDate: '01.01.2020',
                    rate: 14,
                    description: 
                        "I'm Sergey and I want to work as a  web developer.",
                    areas: ['frontend','backend'],
                }
            ]
        }
    },
    mutations: counterMutations,
    actions: counterActions,
    getters: counterGetters,
};
