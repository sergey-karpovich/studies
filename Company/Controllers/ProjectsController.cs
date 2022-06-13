using Microsoft.AspNetCore.Mvc;
using Company.Models;
using Company.Models.Pages;

namespace Company.Controllers{
    public class ProjectsController:Controller{
        private readonly ILogger<HomeController> _logger;
        private IDataRepository repository;
        public ProjectsController(ILogger<HomeController> logger,
            IDataRepository rep)
        {
            _logger = logger;
            repository=rep;
        }
        // public IActionResult Index()
        // {
        //     var model=repository.GetFilteredProjects();
        //     return View(model);
        // }
        public IActionResult Index(QueryOptions options)
        {
            return View(repository.GetProjects(options));
        }
        public IActionResult Create()
        {
            ViewBag.CreateMode=true;
            return View("ProjectEditor",new Project());
        }
        [HttpPost]
        public IActionResult Create(Project project)
        {
            repository.CreateProject(project);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(long id)
        {
            ViewBag.CreateMode=false;
            return View("ProjectEditor",repository.GetProject(id));
        }
        [HttpPost]
        public IActionResult Edit(Project project,Project original)
        {
            repository.UpdateProject(project,original);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult Delete(long id)
        {
            repository.DeleteProject(id);
            return RedirectToAction(nameof(Index));
        }  
    }
}