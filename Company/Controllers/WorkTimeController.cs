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
            IEnumerable<WorkTime> wt=dataRep.GetWorkTimes().Where(e=>e.EmployeeId==id);
            return View("Editor",wt);
        }
        [HttpPost]
        public IActionResult Update(IEnumerable<WorkTime> WorkTimes){            
            if(WorkTimes!=null)
            {
                foreach(WorkTime wt in WorkTimes)
                dataRep.UpdateWorkTime(wt);
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult NewMonth()
        {
            IEnumerable<Employee> employees=dataRep.GetAllEmployee();
            int num=(int)DateTime.Now.Month;
            foreach(Employee e in employees)
            {
                
                WorkTime wt=new WorkTime(){numMonth=num, EmployeeId=e.EmployeeId};
                dataRep.CreateWorkTime(wt);
            }
            //IEnumerable<WorkTime> workTimes=dataRep.GetWorkTimes().Where(e=>e.numMonth==num);
            return View(employees);
        }
        [HttpPost]
        public IActionResult NewMonth(IEnumerable<Employee> employees)
        {
            foreach(Employee e in employees)
            {
                if(e.WorkTimes!=null)
                {
                    foreach (WorkTime wt in e.WorkTimes)
                    {
                        dataRep.CreateWorkTime(wt); 
                    }
                }                               
            }
            return RedirectToAction(nameof(Index));
        }
        
    }
}