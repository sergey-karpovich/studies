using Company.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DataApp.Controllers{
    public class WorkTimeController:Controller{        
        private IDataRepository dataRep;
        public WorkTimeController(IDataRepository data){
            
            dataRep=data;
        }
         public IActionResult Index(){
            ViewBag.EmployeeEditId=TempData["EmployeeEditId"];
            return View(dataRep.GetAllEmployee());
        }
        public IActionResult Edit(long id){
            TempData["EmployeeEditId"]=id;
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult Update(Employee employee){
            foreach(WorkTime wt in employee.WorkTimes)
            dataRep.UpdateWorkTime(wt);
            return RedirectToAction(nameof(Index));
        }
        
    }
}