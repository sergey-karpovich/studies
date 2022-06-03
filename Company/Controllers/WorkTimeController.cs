using Company.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DataApp.Controllers
{
    public class WorkTimeController:Controller
    {        
        private IDataRepository dataRep;
        public WorkTimeController(IDataRepository data)
        {            
            dataRep=data;
        }
         public IActionResult Index()
         {           
            ViewBag.month=(int)DateTime.Now.Month;
            return View(dataRep.GetAllEmployee());
        }
        public IActionResult Edit(long id)
        {          
            WorkTime wt=dataRep.GetWorkTime(id);           
            return View("WorkTimeEditor",wt);
        }
        [HttpPost]
        public IActionResult Edit(WorkTime workTime)
        { 
            dataRep.UpdateWorkTime(workTime);           
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
            IEnumerable<WorkTime> workTimes=dataRep.GetWorkTimes().Where(e=>e.numMonth==num);
            return View(workTimes);
        }
        public IActionResult Month()
        {
            int num=(int)DateTime.Now.Month;
            IEnumerable<WorkTime> month=dataRep.GetWorkTimes().Where(wt=>wt.numMonth==num);
            return View(month);
        }
        [HttpPost]
        public IActionResult Month(WorkTime workTime)
        {
           
            dataRep.UpdateWorkTime(workTime);                    
            return RedirectToAction(nameof(Month));
        }
        
    }
}