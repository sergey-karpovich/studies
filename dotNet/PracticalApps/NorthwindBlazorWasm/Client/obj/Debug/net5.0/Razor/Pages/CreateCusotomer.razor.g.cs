#pragma checksum "C:\git\projects\PriceLessons\PracticalApps\NorthwindBlazorWasm\Client\Pages\CreateCusotomer.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "eab37ef4cc58949fdd46ac5410968a587ecd8d62"
// <auto-generated/>
#pragma warning disable 1591
namespace NorthwindBlazorWasm.Client.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\git\projects\PriceLessons\PracticalApps\NorthwindBlazorWasm\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\git\projects\PriceLessons\PracticalApps\NorthwindBlazorWasm\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\git\projects\PriceLessons\PracticalApps\NorthwindBlazorWasm\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\git\projects\PriceLessons\PracticalApps\NorthwindBlazorWasm\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\git\projects\PriceLessons\PracticalApps\NorthwindBlazorWasm\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\git\projects\PriceLessons\PracticalApps\NorthwindBlazorWasm\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\git\projects\PriceLessons\PracticalApps\NorthwindBlazorWasm\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\git\projects\PriceLessons\PracticalApps\NorthwindBlazorWasm\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\git\projects\PriceLessons\PracticalApps\NorthwindBlazorWasm\Client\_Imports.razor"
using NorthwindBlazorWasm.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\git\projects\PriceLessons\PracticalApps\NorthwindBlazorWasm\Client\_Imports.razor"
using NorthwindBlazorWasm.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\git\projects\PriceLessons\PracticalApps\NorthwindBlazorWasm\Client\_Imports.razor"
using Packt.Shared;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/createcustomer")]
    public partial class CreateCusotomer : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h3>Create Customer</h3>\r\n");
            __builder.OpenComponent<NorthwindBlazorWasm.Client.Pages.CustomerDetail>(1);
            __builder.AddAttribute(2, "ButtonText", "Create Customer");
            __builder.AddAttribute(3, "Customer", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Packt.Shared.Customer>(
#nullable restore
#line 6 "C:\git\projects\PriceLessons\PracticalApps\NorthwindBlazorWasm\Client\Pages\CreateCusotomer.razor"
           customer

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(4, "OnValidSubmit", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, 
#nullable restore
#line 6 "C:\git\projects\PriceLessons\PracticalApps\NorthwindBlazorWasm\Client\Pages\CreateCusotomer.razor"
                                     Create

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
#nullable restore
#line 7 "C:\git\projects\PriceLessons\PracticalApps\NorthwindBlazorWasm\Client\Pages\CreateCusotomer.razor"
       
    private Customer customer = new Customer();
    private async Task Create() 
    { 
        await service.CreateCustomerAsync(customer);
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
