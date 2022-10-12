import axios from 'axios';
export default {
    async loadEmployees(context) {
        const url = context.rootGetters.url;
        // if(!payload.forceRefresh && !context.getters.shouldUpdate){
        //     return;
        // }
        
        const response = await axios.get(
            url+'/employee/'
        );            

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
                description: response.data[emp].Description,
                rate: response.data[emp].Rate,
                areas: response.data[emp].Areas,
                birthDate: response.data[emp].BirthDate,
                hireDate: response.data[emp].HireDate,
                phoneNumber: response.data[emp].HomePhone,
                photoPath: response.data[emp].PhotoPath,
            };
            employees.push(employee);
        }        
        context.commit('setEmployees', employees);

        // context.commit('setFetchTimestamp');
    },
    async registerEmployee(context, employee){
        const url = context.rootGetters.url;
        const employeeData={
            FirstName: employee.firstName,
            LastName: employee.lastName,
            Description: employee.description,
            Rate: employee.hourlyRate,
            Areas: employee.areas.toString(),            
            BirthDate: employee.birthDate,
            HireDate: employee.hireDate,
            HomePhone: employee.phoneNumber,
            PhotoPath: employee.photoPath,
            Address: null,
            City: null,
            Region: null,
            PostalCode: null,
            Country: null,
            Extension: null,
            Photo: null,
            Notes: null,
            ReportsTo: null,
            WorkTimes: null,
            ProjectsEmployees: null
        }        
        const response = await axios.post(url+'/employee/', 
           employeeData
        );
       
        if(!response.status=== 200){
            const error = new Error(response.message || 'Failed to fetch!');
            throw error;
        }
        // context.commit('registerEmployee', employee);
    },
    async updateEmployee(context, employee){
        const url = context.rootGetters.url;
        const employeeData={
            EmployeeId: employee.EmployeeId,
            FirstName: employee.firstName,
            LastName: employee.lastName,
            Description: employee.description,
            Rate: employee.hourlyRate,
            Areas: employee.areas.toString(),            
            BirthDate: employee.birthDate,
            HireDate: employee.hireDate,
            HomePhone: employee.phoneNumber,
            PhotoPath: employee.photoPath,
            Address: null,
            City: null,
            Region: null,
            PostalCode: null,
            Country: null,
            Extension: null,
            Photo: null,
            Notes: null,
            ReportsTo: null,
            WorkTimes: null,
            ProjectsEmployees: null
        }        
        const response = await axios.put(url+'/employee/', 
           employeeData
        );
       
        if(!response.status=== 200){
            const error = new Error(response.message || 'Failed to fetch!');
            throw error;
        }
    },
    async deleteEmployee(context,id){
        const response = await axios.delete('https://localhost:7075/api/employee/'+id);
        if(!response.status === 200){
            const error = new Error(response.message || 'Failed to fetch!');
            throw error;
        }
        context.commit('deleteEmployee',id);
    }

    
}