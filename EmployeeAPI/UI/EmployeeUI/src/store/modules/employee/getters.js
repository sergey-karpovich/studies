export default {
    employees(state){
        return state.employees;
    },
    hasEmployee(state){
        return state.employee && state.employee.length>0;         
    },
    isEmployee(_, getters, _2, rootGetters){
        const employees = getters.employees;
        const userId = rootGetters.userId;
        return employees.some(employee=>employee.id === userId);
    },
    shouldUpdate(state){
        const lastFetch = state.lastFetch;
        if(!lastFetch){
            return true;
        }
        const currentTimeStamp = new Date().getTime();
        return (currentTimeStamp - lastFetch) / 1000 > 60;
    }
};