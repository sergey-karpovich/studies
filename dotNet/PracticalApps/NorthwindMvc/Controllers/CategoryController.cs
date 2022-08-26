using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NorthwindMvc.Models;
using Packt.Shared;
using Microsoft.EntityFrameworkCore;

namespace NorthwindMvc.Controllers
{
    public class CategoryController : Controller
    {
         public CategoryController(Northwind injectedContext)
        {            
            db=injectedContext;
        }
        private Northwind db;
        [Route("category/{id:int?}")]
        public async Task<IActionResult> CategoryDetail(int? id)
        {
            if(!id.HasValue) 
            return NotFound("Нужно ввести ID категории в маршруте, например,/Category/3");
            var model=await db.Categories
                .SingleOrDefaultAsync(c=>c.CategoryID==id);
            if(model==null)
            return NotFound($"Категория с ID = {id} не найдена.");
            return View (model);
        }
    }
}