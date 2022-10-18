import axios from 'axios';

export default {
    async loadProjects(context) {
        const url = context.rootGetters.url;
        // if(!payload.forceRefresh && !context.getters.shouldUpdate){
        //     return;
        // }
        
        const response = await axios.get(
            url+'/projectEmployee'
        );      

        if(!response.status===200){
            const error = new Error(response.message || 'Failed to fetch!');
            throw error;
        }

        const projects = [];

        for (const p in response.data){
            const project = {
                ProjectID: response.data[p].ProjectID,
                ProjectName: response.data[p].ProjectName,
                Budjet: response.data[p].Budjet,
                DateOfAdoption: response.data[p].DateOfAdoption,
                Deadline: response.data[p].Deadline,
                Description: response.data[p].Description,
                Employees: response.data[p].Employees
            }
            projects.push(project);
        }
        context.commit('loadProject', projects)
    },
    async registerProject(context, project){
        const url=context.rootGetters.url;
        const response = await axios.post(url+'/projects',project);

        if(!response.status=== 200){
            const error = new Error(response.message || 'Failed to fetch!');
            throw error;
        }
        context.commit('addProject', response.data)
    },

    async updateProject(context, project){
        const url=context.rootGetters.url+'/projects/';
        console.log('actions', project);
        const response=await axios.put(url, project);

        if(response&&!response.status=== 200){
            const error = new Error(response.message || 'Failed to fetch!');
            throw error;
        }

        context.commit('updateProject', response.data)
    },

    async deleteProject(context, id){
        const response = await axios.delete(context.rootGetters.url+'/projects/'+id)
        if(!response.status === 200){
            const error = new Error(response.message || 'Failed to fetch!');
            throw error;
        }
        context.commit('deleteProject', id)
    },
    async updateJunction(context, id, eids)
    {
        const request={
            id: id,
            eids: eids,
        }
        const url=context.rootGetters.url+'/projectEmployee';
        const response=await axios.put(url,request);
        if(!response.status === 200){
            const error = new Error(response.message || 'Failed to fetch!');
            throw error;
        }
        context.commit('updateProject',response)
    },
   
}