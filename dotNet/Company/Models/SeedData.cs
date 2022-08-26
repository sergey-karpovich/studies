using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Company.Models{
    public static class SeedData{
        public static void Seed(DbContext context)
        {
            if(context.Database.GetPendingMigrations().Count()==0){
                if(context is CompanyContext companyContext)
                    {
                        if( companyContext.Employees.Count()==0){
                            foreach(Employee emp in employee)
                                companyContext.Employees.Add(emp);
                        }
                        if(companyContext.Projects.Count()==0){
                            foreach(Project proj in projects)
                                companyContext.Projects.Add(proj);
                        }                            
                    }                                        
                context.SaveChanges();
            }
        }
        public static void ClearData(DbContext context){
            if(context is CompanyContext ctx )
            {
                if(ctx.Employees.Count()>0)
                    ctx.Employees.RemoveRange(ctx.Employees);
                if(ctx.Projects.Count()>0)
                    ctx.Projects.RemoveRange(ctx.Projects);
                context.SaveChanges();
            }
        }
        private static Employee[]employee{
            get{
                Employee[]emp=new Employee[]{
                    new Employee{FirstName="emp1",LastName="last name1"},
                    new Employee{FirstName="emp2",LastName="last name2"},
                    new Employee{FirstName="emp1",LastName="last name1"}                
                    };
                return emp;
            }
        }
        private static Project[] projects={
            new Project{ProjectName="project1",Description="description1",Deadline=DateTime.Now},
            new Project{ProjectName="project2",Description="description2",Deadline=DateTime.Now},
            new Project{ProjectName="project3",Description="description3",Deadline=DateTime.Now}
        };
    }
}