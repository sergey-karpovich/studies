import axios from "axios"

export default {
    async getInventory(context){        
        var url=context.state.API_URL+'/inventory';       
        let result = await axios.get(url);
        console.log(result.data);
        context.commit('getInventory',result.data)
    }
}