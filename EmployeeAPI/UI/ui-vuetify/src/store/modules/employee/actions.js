import axios from 'axios';

export default {
    async loadEmployees(context) {
        const url = context.rootGetters.url+'/employee/';
        // if(!payload.forceRefresh && !context.getters.shouldUpdate){
        //     return;
        // }
        
        const response = await axios.get(url);            

        if(!response.status===200){
            const error = new Error(response.message || 'Failed to fetch!');
            throw error;
        }

        const employees = [];       

        for (const emp in response.data){
            
            const employee={
                employeeId: response.data[emp].employeeId,
                firstName: response.data[emp].firstName,
                lastName: response.data[emp].lastName,
                description: response.data[emp].description,
                rate: response.data[emp].rate,
                areas: response.data[emp].areas,
                birthDate: response.data[emp].birthDate,
                hireDate: response.data[emp].hireDate,
                homePhone: response.data[emp].homePhone,
                photoPath: response.data[emp].photoPath,
                projects: response.data[emp].projects
            };
            employees.push(employee);
        }        
        context.commit('setEmployees', employees);
        
        // context.commit('setFetchTimestamp');
    },
    async registerEmployee(context, employee){
        const url = context.rootGetters.url+'/employee';
        const employeeData={
            FirstName: employee.firstName,
            LastName: employee.lastName,
            Description: employee.description,
            Rate: employee.rate,
            Areas: employee.areas.toString(),            
            BirthDate: employee.birthDate,
            HireDate: employee.hireDate,
            HomePhone: employee.homePhone,
            PhotoPath: employee.photoPath,
            
        }
        const response = await axios.post(url,employeeData);
        if(!response.status === 200){
            const error = new Error(response.message || 'Failed to fetch!');
            throw error;
        }
        context.commit('registerEmployee', employee);
    },
    async updateEmployee(context, employee){
        const url = context.rootGetters.url+'/employee';
        
        const employeeData={            
            EmployeeId: +employee.employeeId,
            FirstName: employee.firstName,
            LastName: employee.lastName,
            Description: employee.description,
            Rate: employee.rate,
            Areas: employee.areas.toString(),            
            BirthDate: employee.birthDate,
            HireDate: employee.hireDate,
            HomePhone: employee.homePhone,
            PhotoPath: employee.photoPath,    
        }  
         console.log(employeeData);     
        const  response = await axios.put(url, employeeData);
        // если будет ошибка на сервере то все зависнет. 
        // надо будет разобраться с promises и сделать таймер
        // также надо на сервере организовать отлов ошибок
        // const timeout=function(sec){
        //     return new Promise(function(_, reject){
        //         setTimeout(function(){
        //             reject( new Error('Request took too long'))
        //         }, sec*1000)
        //     })
        // }
        // const some = Promise.race( timeout(5)).catch(err=>{
            //     const error = new Error(err.message || 'Failed to fetch!');
            //     throw error;
            // });       
            
            if(response&&!response.status=== 200){
                const error = new Error(response.message || 'Failed to fetch!');
                throw error;
        }
        
        context.commit('deleteEmployee',employee.employeeId);
        context.commit('registerEmployee',employeeData);
    },
    async deleteEmployee(context,id){
        const response = await axios.delete('https://localhost:7075/api/employee/'+id);
        if(!response.status === 200){
            const error = new Error(response.message || 'Failed to fetch!');
            throw error;
        }
        context.commit('deleteEmployee',id);
    },
    
    
    
}