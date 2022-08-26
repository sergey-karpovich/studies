#pragma checksum "C:\git\projects\PriceLessons\PracticalApps\NorthwindBlazorServer\Pages\EditCustomer.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6bb94f5f64c855bf9882bf3511afa2f105c0cc94"
// <auto-generated/>
#pragma warning disable 1591
namespace NorthwindBlazorServer.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\git\projects\PriceLessons\PracticalApps\NorthwindBlazorServer\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\git\projects\PriceLessons\PracticalApps\NorthwindBlazorServer\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\git\projects\PriceLessons\PracticalApps\NorthwindBlazorServer\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\git\projects\PriceLessons\PracticalApps\NorthwindBlazorServer\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\git\projects\PriceLessons\PracticalApps\NorthwindBlazorServer\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\git\projects\PriceLessons\PracticalApps\NorthwindBlazorServer\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\git\projects\PriceLessons\PracticalApps\NorthwindBlazorServer\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\git\projects\PriceLessons\PracticalApps\NorthwindBlazorServer\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\git\projects\PriceLessons\PracticalApps\NorthwindBlazorServer\_Imports.razor"
using NorthwindBlazorServer;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\git\projects\PriceLessons\PracticalApps\NorthwindBlazorServer\_Imports.razor"
using NorthwindBlazorServer.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\git\projects\PriceLessons\PracticalApps\NorthwindBlazorServer\_Imports.razor"
using NorthwindBlazorServer.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\git\projects\PriceLessons\PracticalApps\NorthwindBlazorServer\_Imports.razor"
using Microsoft.EntityFrameworkCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\git\projects\PriceLessons\PracticalApps\NorthwindBlazorServer\_Imports.razor"
using Packt.Shared;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/editcustomer/{customerid}")]
    public partial class EditCustomer : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h3>Edit\r\n    Customer</h3>\r\n");
            __builder.OpenComponent<NorthwindBlazorServer.Pages.CustomerDetail>(1);
            __builder.AddAttribute(2, "ButtonText", "Update");
            __builder.AddAttribute(3, "Customer", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Packt.Shared.Customer>(
#nullable restore
#line 7 "C:\git\projects\PriceLessons\PracticalApps\NorthwindBlazorServer\Pages\EditCustomer.razor"
           customer

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(4, "OnValidSubmit", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, 
#nullable restore
#line 7 "C:\git\projects\PriceLessons\PracticalApps\NorthwindBlazorServer\Pages\EditCustomer.razor"
                                     Update

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
#nullable restore
#line 8 "C:\git\projects\PriceLessons\PracticalApps\NorthwindBlazorServer\Pages\EditCustomer.razor"
       
    [Parameter] 
    public string CustomerID { get; set; }
    private Customer customer = new Customer();
    protected async override Task OnParametersSetAsync() 
    {
        customer = await service.GetCustomerAsync(CustomerID); 
    }
    private async Task Update() 
    { 
        await service.UpdateCustomerAsync(customer); 
        navigation.NavigateTo("customers"); 
    } 

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager navigation { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private INorthwindService service { get; set; }
    }
}
#pragma warning restore 1591
