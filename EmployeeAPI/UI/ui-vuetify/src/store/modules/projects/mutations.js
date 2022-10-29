export default {
    addProject(state, project){
        state.projects.unshift(project);
    },
    loadProject(state, payload){
        state.projects=payload;
    },
    deleteProject(state,id){
        state.projects = state.projects.filter(p=>p.ProjectId!=id);
    },
    selectProject(state, num){
        state.selectedProject=state.projects[num];
    },
    setFetchTimestamp(state){
        state.lastFetch = new Date().getTime();
    },
}