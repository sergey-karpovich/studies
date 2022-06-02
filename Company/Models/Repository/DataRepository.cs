using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Company.Models
{
    public class DataRepository : IDataRepository
    {
        private readonly CompanyContext context;
        public DataRepository(CompanyContext ctx)
        {
            context=ctx;
        }

        public void CreateEmployee(Employee newEmployee)
        {
            //newEmployee.EmployeeId=0;
            if(context.Employees!=null) 
            {
                context.Employees.Add(newEmployee);
                context.SaveChanges();
            }
        }

        public void DeleteEmployee(long id)
        {
            context.Employees.Remove(new Employee{EmployeeId=id});
            context.SaveChanges();
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return context.Employees.Include(p=>p.WorkTimes);
        }

        public Employee GetEmployee(long id)
        {
           
           return context.Employees.Find(id)??(new Employee());
        }

        public IEnumerable<Employee> GetFilteredEmployee(string? title = null,
            int? reportsTo = null)
        {
            IQueryable<Employee>data=context.Employees;
            if(title!=null)
                data=data.Where(p=>p.Title==title);
            if(reportsTo!=null)
                data=data.Where(p=>p.ReportsTo==reportsTo);
            return data;
        }

        public void UpdateEmployee(Employee changeEmployee, Employee originalEmployee)
        {
            if(originalEmployee==null)
                originalEmployee=context.Employees.Find(changeEmployee)??new Employee();
            else 
                context.Employees.Attach(originalEmployee);
            originalEmployee.Address=changeEmployee.Address;
            originalEmployee.BirthDate=changeEmployee.BirthDate;
            originalEmployee.City=changeEmployee.City;
            originalEmployee.Country=changeEmployee.Country;
            originalEmployee.Extension=changeEmployee.Extension;
            originalEmployee.FirstName=changeEmployee.FirstName;
            originalEmployee.HireDate=changeEmployee.HireDate;
            originalEmployee.HomePhone=changeEmployee.HomePhone;
            originalEmployee.LastName=changeEmployee.LastName;
            originalEmployee.Notes=changeEmployee.Notes;
            originalEmployee.Photo=changeEmployee.Photo;
            originalEmployee.PhotoPath=changeEmployee.PhotoPath;
            originalEmployee.PostalCode=changeEmployee.PostalCode;
            originalEmployee.Region=changeEmployee.Region;
            originalEmployee.ReportsTo=changeEmployee.ReportsTo;
            originalEmployee.Title=changeEmployee.Title;
            originalEmployee.TitleOfCourtesy=changeEmployee.TitleOfCourtesy;
            context.SaveChanges();
        }
        
         public IEnumerable<Project> GetFilteredProjects()
        {
            IQueryable<Project>data=context.Projects;
            return data;
        }

        public Project GetProject(long id)
        {
            return context.Projects.Find(id)??(new Project());
        }

        public void CreateProject(Project newProject)
        {
            if(context.Projects!=null) 
            {
                context.Projects.Add(newProject);
                context.SaveChanges();
            }
        }

        public void UpdateProject(Project changeProject, Project originalProject)
        {
            if(originalProject==null)
                originalProject=context.Projects.Find(changeProject)??new Project();
            else 
                context.Projects.Attach(originalProject);
            originalProject.ProjectName=changeProject.ProjectName;
            originalProject.Description=changeProject.Description;
            originalProject.DateOfAdoption=changeProject.DateOfAdoption;
            originalProject.Deadline=changeProject.Deadline;
            originalProject.Budjet=changeProject.Budjet;
            context.SaveChanges();
        }

        public void DeleteProject(long id)
        {
            context.Projects.Remove(new Project(){ProjectID=id});
            context.SaveChanges();
        }

        public IEnumerable<WorkTime> GetWorkTimes()
        {
             if(context.WorkTimes!=null) 
            {
                return context.WorkTimes.ToArray();
            }
            return new List<WorkTime>();
        }

        public WorkTime GetWorkTime(long id)
        {
             if(context.WorkTimes!=null) 
            {
                return context.WorkTimes.First(w=>w.Id==id);
            }
            return new WorkTime();
        }

        public void CreateWorkTime(WorkTime newWT)
        {
            if(context.WorkTimes!=null) 
            {
                context.WorkTimes.Add(newWT);
                context.SaveChanges();
            }
        }

        public void UpdateWorkTime(WorkTime workTime)
        {
            if(context.WorkTimes!=null) 
            {
                context.WorkTimes.Update(workTime);
                context.SaveChanges();
            }
        }

        public void DeleteWorkTime(long id)
        {
            context.WorkTimes.Remove(new WorkTime(){Id=id});
            context.SaveChanges();
        }
    }
}