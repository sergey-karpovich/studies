using Company.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Company.Controllers
{
    public class ProjectEmployeeController:Controller
    {
        private CompanyContext context;
        public ProjectEmployeeController(CompanyContext ctx)=>context=ctx;
        public IActionResult Index()
        {
            ViewBag.Projects=context.Projects;
            ViewBag.Employee=context.Employees;
            return View(context.Projects.Include(p=>p.ProjectsEmployees)
                .ThenInclude(e=>e.Employee));                
        }
        public IActionResult Edit(long id)
        {
            ViewBag.Projects=context.Projects;
            ViewBag.Employee=context.Employees
                .Include(e=>e.WorkTimes);
            return View(context.Projects.Include(p=>p.ProjectsEmployees)
                .ThenInclude(p=>p.Employee).First(s=>s.ProjectID==id)); 
        }
        public IActionResult Update(long id , long[]pids)
        {
            Project project=context.Set<Project>()
            .Include(s=>s.ProjectsEmployees).First(s=>s.ProjectID==id);
            project.ProjectsEmployees=pids.Select(pid
                =>new ProjectEmployeeJunction {
                ProjectId=id,EmployeeId=pid
                })
                .ToList();
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}