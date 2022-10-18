export default {
    addProject(state, project){
        state.projects.push(project);
    },
    loadProject(state, payload){
        state.projects=payload;
    },
    deleteProject(state,id){
        state.projects = state.projects.filter(p=>p.ProjectID!=id);
    },
    selectProject(state, num){
        state.selectedProject=state.projects[num];
    },
    updateProject(state, project){
        state.projects = state.projects.filter(p=>p.ProjectID!=project.ProjectID);
        state.projects.push(project);
    }
}