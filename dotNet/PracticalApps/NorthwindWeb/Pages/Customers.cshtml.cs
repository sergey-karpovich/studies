using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using Packt.Shared;
using Microsoft.AspNetCore.Mvc;


namespace NorthwindWeb.Pages
{
  public class CustomersModel : PageModel
  {
    private Northwind db;
    public CustomersModel(Northwind injectedContext)
    {
      db=injectedContext;
    }
    public IEnumerable<Customer> Customers{get;set;}
    public void OnGet()
    {
      ViewData["Title"]="Northwind Web Site - Customers";
      Customers=db.Customers.OrderBy(c=>c.Country);
    }
    [BindProperty]
    public Customer Customer{get;set;}
    public IActionResult OnPost()
    {
      if(ModelState.IsValid)
      {
        db.Customers.Add(Customer);
        db.SaveChanges();
        return RedirectToPage("/customers");
      }
      return Page();
    }
  }
}