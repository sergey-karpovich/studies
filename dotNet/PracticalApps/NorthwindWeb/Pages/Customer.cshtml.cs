using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using Packt.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NorthwindWeb.Pages
{
  public class CustomerModel : PageModel
  {
    private Northwind db;
    public CustomerModel(Northwind injectedContext)
    {
      db=injectedContext;
    }
    
    [BindProperty]
    public Customer Customer{get;set;}
    [BindProperty(SupportsGet=true)]
    public string ID{get;set;}
    public void OnGet()
    {
       ViewData["Title"]="Northwind Web Site - Customer";

       Customer=db.Customers
        .Where(c=>c.CustomerID==ID)
        .Include(c=>c.Orders)
        .ThenInclude(o=>o.OrderDetails)
        .ThenInclude(d=>d.Product)
        .FirstOrDefault();
    }
  }
}