using EmployeeAPI.Models;

namespace EmployeeAPI.Models.Repository
{
    public interface IDataRepository
    {
        IEnumerable<Employee> GetAllEmployee();
        Employee GetEmployee(long id);
        IEnumerable<Employee> GetFilteredEmployee(string? title = null, int? reportsTo = null);
        void CreateEmployee(Employee newEmployee);
        void UpdateEmployee(Employee changeEmployee, Employee originalEmployee);
        void DeleteEmployee(long id);

        IEnumerable<Project> GetProjects();
        Project GetProject(long id);
        void CreateProject(Project newProject);
        void UpdateProject(Project changeProject, Project originalProject);
        void DeleteProject(long id);

        IEnumerable<WorkTime> GetWorkTimes();
        IEnumerable<WorkTime> GetWorkTime(long id);
        void CreateWorkTime(WorkTime newWT);
        void UpdateWorkTime(WorkTime workTime);
        void DeleteWorkTime(long id);
    }
}
