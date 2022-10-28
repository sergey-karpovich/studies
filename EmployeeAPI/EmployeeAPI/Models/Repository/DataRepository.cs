using Microsoft.EntityFrameworkCore;
using EmployeeAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Models.Repository
{
    public class DataRepository :IDataRepository
    {
        private readonly CompanyContext context;
        public DataRepository(CompanyContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<Object> GetAllEmployee()
        {           
            var employees = context.Employees.Select(e =>
            new {
                e.EmployeeId,
                e.FirstName,
                e.LastName,
                e.Description,
                e.Rate,
                e.Areas,
                e.BirthDate,
                e.HireDate,
                e.HomePhone,
                e.PhotoPath,
                e.Projects
            }).ToList();

            return employees;
        }
        public void CreateEmployee(Employee newEmployee)
        {            
            if (context.Employees != null)
            {                               
                context.Employees.Add(newEmployee);
                context.SaveChanges();
            }
        }
        public void DeleteEmployee(long id)
        {
            try
            {
                context.Employees.Remove(new Employee { EmployeeId = id });
                context.SaveChanges();
            }
            catch(Exception err) 
            {
                Console.WriteLine($"Ошибка: {err.Message}");
            }
        }
        public Employee GetEmployee(long id)
        {
            return context.Employees.Find(id) ?? (new Employee());
        }
        public IEnumerable<Employee> GetFilteredEmployee(string? area = null,
           int? reportsTo = null)
        {
            IQueryable<Employee> data = context.Employees;
            if (area != null)
                data = data.Where(p => p.Areas.Contains(area));
            if (reportsTo != null)
                data = data.Where(p => p.ReportsTo == reportsTo);
            return data;
        }
        public void UpdateEmployee(Employee changeEmployee, Employee originalEmployee)
        {
            if (originalEmployee == null)
                originalEmployee = context.Employees.Find(changeEmployee) ?? new Employee();
            else
                context.Employees.Attach(originalEmployee);
            originalEmployee.FirstName = changeEmployee.FirstName;
            originalEmployee.LastName = changeEmployee.LastName;
            originalEmployee.Description = changeEmployee.Description;
            originalEmployee.Areas = changeEmployee.Areas;
            originalEmployee.Rate = changeEmployee.Rate;
            originalEmployee.BirthDate = changeEmployee.BirthDate;
            originalEmployee.HireDate = changeEmployee.HireDate;
            originalEmployee.HomePhone = changeEmployee.HomePhone;
            originalEmployee.PhotoPath = changeEmployee.PhotoPath;

            originalEmployee.Address = changeEmployee.Address;
            originalEmployee.City = changeEmployee.City;
            originalEmployee.Region = changeEmployee.Region;
            originalEmployee.PostalCode = changeEmployee.PostalCode;
            originalEmployee.Country = changeEmployee.Country;
            originalEmployee.Extension = changeEmployee.Extension;
            originalEmployee.Photo = changeEmployee.Photo;
            originalEmployee.Notes = changeEmployee.Notes;
            context.SaveChanges();
        }


        // Projects 
        //////////////////
        public IEnumerable<Project> GetProjects()
        {
            return context.Projects.AsNoTracking()
                .Include(p=>p.Employees)
                .ToList();
        }
        public Project GetProject(long id)
        {
            return context.Projects.Find(id) ?? (new Project());
        }

        public void CreateProject(Project newProject)
        {
            if (context.Projects != null)
            {
                context.Projects.Add(newProject);
                context.SaveChanges();
            }
        }

        public void UpdateProject(Project changeProject, Project originalProject)
        {
            if (originalProject == null)
                originalProject = context.Projects.Find(changeProject) ?? new Project();
            else
                context.Projects.Attach(originalProject);
                originalProject.ProjectName = changeProject.ProjectName;
                originalProject.Description = changeProject.Description;
                originalProject.DateOfAdoption = changeProject.DateOfAdoption;
                originalProject.Deadline = changeProject.Deadline;
                originalProject.Budjet = changeProject.Budjet;
                //originalProject.Employees = changeProject.Employees;
                context.SaveChanges();
        }

        public void DeleteProject(long id)
        {
            context.Projects.Remove(new Project() { ProjectId = id });
            context.SaveChanges();
        }

        // WorkTime
        ////////////////////

        public IEnumerable<WorkTime> GetWorkTimes()
        {
            if (context.WorkTimes != null)
            {
                return context.WorkTimes.ToArray();
            }
            return new List<WorkTime>();
        }

        public IEnumerable<WorkTime> GetWorkTime(long id)
        {
            if (context.WorkTimes != null)
            {
                return context.WorkTimes.Where(w => w.EmployeeId == id);
            }
            return new List<WorkTime>();
        }
        public async Task<ActionResult<IEnumerable<WorkTime>>> GetWorkTimeByMonthYear(int month, int year)
        {
            if(month == 0 || year == 0)
            {
                var currentDate = DateTime.Now;
                month = currentDate.Month;                
                year = currentDate.Year;
            }
            var workTime = await context.WorkTimes.Where(wt => wt.NumMonth == month && wt.NumYear == year).ToListAsync();
            return workTime;
        }

        public void CreateWorkTime(WorkTime newWT)
        {
            if (context.WorkTimes != null)
            {
                context.WorkTimes.Add(newWT);
                context.SaveChanges();
            }
        }

        public void UpdateWorkTime(WorkTime workTime)
        {
            if (context.WorkTimes != null)
            {
                context.WorkTimes.Update(workTime);
                context.SaveChanges();
            }
        }

        public void DeleteWorkTime(long id)
        {
            context.WorkTimes.Remove(new WorkTime() { Id = id });
            context.SaveChanges();
        }

    }
}
