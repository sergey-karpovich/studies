export default {
    projects(state){
        return state.projects;
    },
    projectByNumber(state){
        return state.selectedProject
    },
    shouldUpdate(state){
        const lastFetch = state.lastFetch;
        if(!lastFetch){
            return true;
        }
        const currentTimeStamp = new Date().getTime();        
        return (currentTimeStamp - lastFetch) / 1000 > 60;
    },
}