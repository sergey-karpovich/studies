import mutations from './mutations.js';
import actions from './actions.js';
import getters from './getters.js';

export default {    
    state(){
        return{
            isAuthenticated: true,
            // userId: null,
            // token: null,
            // apiKey: 'AIzaSyD2RnJValLb4MOj531KNMu7x77KTZzWwO8',
            // loginURL: 'https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword',
            // signupURL: 'https://identitytoolkit.googleapis.com/v1/accounts:signUp',
            // didAutoLogout: false,
        }
    },
    mutations,
    actions,
    getters,
};

