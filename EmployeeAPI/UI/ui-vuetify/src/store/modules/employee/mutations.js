export default {
    registerEmployee(state, employee){    
        state.employees.unshift(employee);
    },
    setEmployees(state, payload){
        state.employees = payload;
    },
    setFetchTimestamp(state){
        state.lastFetch = new Date().getTime();
    },
    deleteEmployee(state,id){
        state.employees = state.employees.filter(emp=>emp.employeeId!=id);
    }
};