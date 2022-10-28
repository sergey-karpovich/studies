import axios from 'axios';

export default {
    async loadProjects(context) {
        const url = context.rootGetters.url+'/Projects';
        // if(!payload.forceRefresh && !context.getters.shouldUpdate){
        //     return;
        // }
        
        const response = await axios.get(url);      

        if(!response.status===200){
            const error = new Error(response.message || 'Failed to fetch!');
            throw error;
        }

        const projects = [];

        for (const p in response.data){
            const project = {
                ProjectId: response.data[p].projectId,
                ProjectName: response.data[p].projectName,
                Budjet: response.data[p].budjet,
                DateOfAdoption: response.data[p].dateOfAdoption,
                Deadline: response.data[p].deadline,
                Description: response.data[p].description,
                Employees: response.data[p].employees
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
        context.commit('addProject', project)
    },

    async updateProject(context, project){
        const url=context.rootGetters.url+'/projects/';
        const response=await axios.put(url, project);

        if(response&&!response.status=== 200){
            const error = new Error(response.message || 'Failed to fetch!');
            throw error;
        }
        context.commit('deleteProject',project.ProjectId)
        context.commit('addProject', project)
    },
    async addEmployeesById(context, junction){
        const url=context.rootGetters.url+'/ProjectEmployee';
        console.log('action id',junction)
        const response=await axios.put(url, junction);

        if(response&&!response.status=== 200){
            const error = new Error(response.message || 'Failed to fetch!');
            throw error;
        }        
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