#pragma checksum "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\Page.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9b11993e2e9a3f9602eb06bf7efce2c290915bca"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cms_Page), @"mvc.1.0.view", @"/Views/Cms/Page.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9b11993e2e9a3f9602eb06bf7efce2c290915bca", @"/Views/Cms/Page.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"107f1184d77f80a4fa29c7df5bfcea3406f2da9c", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Cms_Page : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<NorthwindCms.Models.StandardPage>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\Page.cshtml"
  
    ViewBag.Title = Model.Title;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container\">\r\n    <h1>");
#nullable restore
#line 7 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\Page.cshtml"
   Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\n    ");
#nullable restore
#line 9 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\Page.cshtml"
Write(Html.DisplayFor(m => m.Blocks));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Piranha.AspNetCore.Services.IApplicationService WebApp { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<NorthwindCms.Models.StandardPage> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
