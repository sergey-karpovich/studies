using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Company.Models;

namespace Company.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IDataRepository repository;
        public HomeController(ILogger<HomeController> logger,
            IDataRepository rep)
        {
            _logger = logger;
            repository=rep;
        }
        public IActionResult Index(string? title=null,int? reportsTo=null)
        {
            var model=repository.GetFilteredEmployee(title,reportsTo);
            ViewBag.title=title;
            ViewBag.reportsTo=reportsTo;
            return View(model);
        }
        public IActionResult Create()
        {
            ViewBag.CreateMode=true;
            return View("Editor",new Employee());
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            repository.CreateEmployee(employee);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(long id)
        {
            ViewBag.CreateMode=false;
            return View("Editor",repository.GetEmployee(id));
        }
        [HttpPost]
        public IActionResult Edit(Employee employee,Employee original)
        {
            repository.UpdateEmployee(employee,original);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult Delete(long id)
        {
            repository.DeleteEmployee(id);
            return RedirectToAction(nameof(Index));
        }        
    }
}
