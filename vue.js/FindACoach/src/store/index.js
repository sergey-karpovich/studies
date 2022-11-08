import { createStore } from 'vuex';

import rootMutations from './mutations.js';
import rootActions from './actions.js';
import rootGetters from './getters.js';

import coachesModule from './modules/coaches/index.js';
import requestsModule from './modules/requests/index.js';
import authModule from './modules/auth/index.js';


 const store=createStore({
    modules:{
        coaches: coachesModule,
        requests: requestsModule,
        auth: authModule,
    },
    
    mutations: rootMutations,
    actions: rootActions,
    getters: rootGetters,
});

export default store;