import axios from 'axios';

export default {          
    async loadWorkTime(context){
        const url =context.rootGetters.url+'/WorkTine';
        const response = await axios.get(url);

        if(!response.status===200){
            const error = new Error(response.message || 'Failed to fetch!');
            throw error;
        }
        context.commit('loadWorkTime', response.data);
    }
          

}