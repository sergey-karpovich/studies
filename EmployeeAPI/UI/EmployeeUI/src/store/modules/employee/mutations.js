export default {
    registerEmployee(state, employee){    
        state.Employees.unshift(employee);
    },
    setEmployees(state, payload){
        state.employees = payload;
    },
    setFetchTimestamp(state){
        state.lastFetch = new Date().getTime();
    },
};