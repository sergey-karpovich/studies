﻿using EmployeeAPI.Models;
using EmployeeAPI.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {        
        private IDataRepository repository;
        public ProjectsController(           
            IDataRepository rep)
        {           
            repository = rep;
        }

        [HttpGet]
        public JsonResult Get()
        {
            var table = repository.GetProjects();
            return new JsonResult(table);
        }
        [HttpPost]
        public JsonResult Post(Project project)
        {
            if (project != null)
            {
                repository.CreateProject(project);
                return new JsonResult("Added Successfully");
            }
            else
            {
                return new JsonResult("Error");
            }
        }
        [HttpPut]
        public JsonResult Put(Project newProject)
        {
            if (newProject != null)
            {
                var oldEmployee = repository.GetProject((long)newProject.ProjectID);

                repository.UpdateProject(newProject, oldEmployee);
                return new JsonResult("Updated Successfully");
            }
            else
            {
                return new JsonResult("Error");
            }
        }
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            repository.DeleteProject(id);
            return new JsonResult("Deleted Successfully");
        }

        
    }
}