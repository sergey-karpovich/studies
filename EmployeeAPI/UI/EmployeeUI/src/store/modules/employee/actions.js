import axios from 'axios';
export default {
    async loadEmployees(context) {
        // if(!payload.forceRefresh && !context.getters.shouldUpdate){
        //     return;
        // }
        const url = context.rootGetters.url;
        const response = await axios.get(
            `${url}/employee`
        );
        // console.log(response);       

        if(!response.status===200){
            const error = new Error(response.message || 'Failed to fetch!');
            throw error;
        }

        const employees = [];       

        for (const emp in response.data){
            const employee={
                EmployeeId: response.data[emp].EmployeeId,
                firstName: response.data[emp].FirstName,
                lastName: response.data[emp].LastName,
                hireDate: response.data[emp].HireDate,
                title: response.data[emp].Title,
            };
            employees.push(employee);
        }
        // console.log(employees);
        context.commit('setEmployees', employees);

        // context.commit('setFetchTimestamp');
    }

    // async registerEmployee(context, employee) {
    //     // const userId = context.rootGetters.userId;
    //     const employeeData={            
    //         firstName: employee.firstName,
    //         lastName: employee.lastName,
    //         description: employee.description,
    //         hourlyRate: employee.hourlyRate,
    //         areas: employee.areas,
    //     };

    //     // const token = context.rootGetters.token;

    //     const response = await fetch(
    //         // `https://vue-http-demo-d6e2b-default-rtdb.europe-west1.firebasedatabase.app/employeees/${userId}.json?auth=`+
    //         // token,
    //     {
    //         method: 'PUT',
    //         body: JSON.stringify(employeeData)
    //     });

    //     const responseData = await response.json();

    //     if(!response.ok){
    //         const error = new Error(responseData.message || 'Failed to fetch!');
    //         throw error;
    //     }

    //     context.commit('registerEmployee',{
    //         ...employeeData,
    //         id: userId
    //     });
    // },
    // 
}