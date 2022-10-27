import Mutations from './mutations.js';
import Actions from './actions.js';
import Getters from './getters.js';

export default { 
    namespaced: true,
    state(){
        return{
           workTime:[
            {
                "Id": 1,
                "NumMonth": 1,
                "Hours": 8,
                "LastRate": 14.0,
                "EmployeeId": 1,
                "ProjectId": 1
            },
            {
                "Id": 4,
                "NumMonth": 2,
                "Hours": 8,
                "LastRate": 14.0,
                "EmployeeId": 1,
                "ProjectId": 2
            }
           ],
        };
    },
    mutations: Mutations,
    actions: Actions,
    getters: Getters,
};

