export default {
    addProject(state, project){
        state.projects.push(project);
    },
    loadProject(state, payload){
        state.projects=payload;
    },
    deleteProject(state,id){
        state.projects = state.projects.filter(emp=>emp.ProjectId!=id);
    },
    selectProject(state, num){
        state.selectedProject=state.projects[num];
    }
}