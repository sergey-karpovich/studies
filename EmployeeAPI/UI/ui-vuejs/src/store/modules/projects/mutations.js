export default {
    addRequest(state,request){
        state.requests.push(request);
    },
    loadRequests(state, payload){
        state.requests=payload;
    }
}