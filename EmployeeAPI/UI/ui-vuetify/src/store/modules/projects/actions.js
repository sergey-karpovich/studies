import axios from 'axios';

export default {
    async loadProjects(context) {
        const url = context.rootGetters.url;
        // if(!payload.forceRefresh && !context.getters.shouldUpdate){
        //     return;
        // }
        
        const response = await axios.get(
            url+'/projects'
        );            
        if(!response.status===200){
            const error = new Error(response.message || 'Failed to fetch!');
            throw error;
        }
        console.log(response.data);
        context.commit('loadProject',response.data)
    }
   
}