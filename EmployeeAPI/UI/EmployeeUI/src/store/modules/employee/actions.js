export default {
    async registeremployee(context, employee) {
        // const userId = context.rootGetters.userId;
        const employeeData={            
            firstName: employee.firstName,
            lastName: employee.lastName,
            description: employee.description,
            hourlyRate: employee.hourlyRate,
            areas: employee.areas,
        };

        // const token = context.rootGetters.token;

        const response = await fetch(
            // `https://vue-http-demo-d6e2b-default-rtdb.europe-west1.firebasedatabase.app/employeees/${userId}.json?auth=`+
            // token,
        {
            method: 'PUT',
            body: JSON.stringify(employeeData)
        });

        const responseData = await response.json();

        if(!response.ok){
            const error = new Error(responseData.message || 'Failed to fetch!');
            throw error;
        }

        context.commit('registerEmployee',{
            ...employeeData,
            id: userId
        });
    },
    async loadEmployees(context, payload) {
        if(!payload.forceRefresh && !context.getters.shouldUpdate){
            return;
        }
        
        const response = await fetch(
            `https://vue-http-demo-d6e2b-default-rtdb.europe-west1.firebasedatabase.app/employeees.json`
        );
        const responseData = await response.json();

        if(!response.ok){
            const error = new Error(responseData.message || 'Failed to fetch!');
            throw error;
        }

        const employees = [];

        for (const key in responseData){
            const employee ={
                EmployeeId: key,
                firstName: responseData[key].firstName,
                lastName: responseData[key].lastName,
                description: responseData[key].description,
                hourlyRate: responseData[key].hourlyRate,
                areas: responseData[key].areas,
            };
            employees.push(employee);
        }

        context.commit('setEmployees', employees);
        context.commit('setFetchTimestamp');
    }
}