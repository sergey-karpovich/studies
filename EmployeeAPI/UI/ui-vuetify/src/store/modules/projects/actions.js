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

        const projects = [];

        for (const p in response.data){
            const project = {
                ProjectID: response.data[p].ProjectID,
                ProjectName: response.data[p].ProjectName,
                Budjet: response.data[p].Budjet,
                DateOfAdoption: response.data[p].DateOfAdoption,
                Deadline: response.data[p].Deadline,
                Description: response.data[p].Description,
                ProjectsEmployees: response.data[p].ProjectsEmployees
            }
            projects.push(project);
        }
        context.commit('loadProject', projects)
    }
   
}