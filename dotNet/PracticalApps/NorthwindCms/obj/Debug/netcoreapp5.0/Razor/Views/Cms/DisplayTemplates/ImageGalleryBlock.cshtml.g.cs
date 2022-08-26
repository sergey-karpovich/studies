#pragma checksum "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\DisplayTemplates\ImageGalleryBlock.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "84218324386f62c3c3ff568d7193100796c45960"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cms_DisplayTemplates_ImageGalleryBlock), @"mvc.1.0.view", @"/Views/Cms/DisplayTemplates/ImageGalleryBlock.cshtml")]
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
#nullable restore
#line 2 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\DisplayTemplates\ImageGalleryBlock.cshtml"
using Piranha.Extend.Blocks;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"84218324386f62c3c3ff568d7193100796c45960", @"/Views/Cms/DisplayTemplates/ImageGalleryBlock.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"107f1184d77f80a4fa29c7df5bfcea3406f2da9c", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Cms_DisplayTemplates_ImageGalleryBlock : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Piranha.Extend.Blocks.ImageGalleryBlock>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\DisplayTemplates\ImageGalleryBlock.cshtml"
  
    var unique = "gallery-" + Guid.NewGuid().ToString();

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div");
            BeginWriteAttribute("id", " id=\"", 149, "\"", 161, 1);
#nullable restore
#line 7 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\DisplayTemplates\ImageGalleryBlock.cshtml"
WriteAttributeValue("", 154, unique, 154, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"carousel slide gallery-block\" data-ride=\"carousel\">\r\n    <ol class=\"carousel-indicators\">\r\n");
#nullable restore
#line 9 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\DisplayTemplates\ImageGalleryBlock.cshtml"
         for (var n = 0; n < Model.Items.Count; n++)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li data-target=\"#");
#nullable restore
#line 11 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\DisplayTemplates\ImageGalleryBlock.cshtml"
                         Write(unique);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-slide-to=\"");
#nullable restore
#line 11 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\DisplayTemplates\ImageGalleryBlock.cshtml"
                                                 Write(n);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"");
            BeginWriteAttribute("class", " class=\"", 383, "\"", 416, 1);
#nullable restore
#line 11 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\DisplayTemplates\ImageGalleryBlock.cshtml"
WriteAttributeValue("", 391, n == 0 ? "active" : "", 391, 25, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></li>\r\n");
#nullable restore
#line 12 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\DisplayTemplates\ImageGalleryBlock.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </ol>\r\n    <div class=\"carousel-inner\">\r\n");
#nullable restore
#line 15 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\DisplayTemplates\ImageGalleryBlock.cshtml"
         foreach (var item in Model.Items)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div");
            BeginWriteAttribute("class", " class=\"", 552, "\"", 620, 2);
            WriteAttributeValue("", 560, "carousel-item", 560, 13, true);
#nullable restore
#line 17 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\DisplayTemplates\ImageGalleryBlock.cshtml"
WriteAttributeValue(" ", 573, item == Model.Items.First() ? "active" : "", 574, 46, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                <img");
            BeginWriteAttribute("src", " src=\"", 644, "\"", 729, 1);
#nullable restore
#line 18 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\DisplayTemplates\ImageGalleryBlock.cshtml"
WriteAttributeValue("", 650, Url.Content(WebApp.Media.ResizeImage(((ImageBlock)item).Body.Media, 890, 482)), 650, 79, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"d-block w-100\">\r\n            </div>\r\n");
#nullable restore
#line 20 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\DisplayTemplates\ImageGalleryBlock.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n    <a class=\"carousel-control-prev\"");
            BeginWriteAttribute("href", " href=\"", 834, "\"", 849, 2);
            WriteAttributeValue("", 841, "#", 841, 1, true);
#nullable restore
#line 22 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\DisplayTemplates\ImageGalleryBlock.cshtml"
WriteAttributeValue("", 842, unique, 842, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" role=\"button\" data-slide=\"prev\">\r\n        <span class=\"carousel-control-prev-icon\" aria-hidden=\"true\"></span>\r\n        <span class=\"sr-only\">Previous</span>\r\n    </a>\r\n    <a class=\"carousel-control-next\"");
            BeginWriteAttribute("href", " href=\"", 1055, "\"", 1070, 2);
            WriteAttributeValue("", 1062, "#", 1062, 1, true);
#nullable restore
#line 26 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\DisplayTemplates\ImageGalleryBlock.cshtml"
WriteAttributeValue("", 1063, unique, 1063, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" role=\"button\" data-slide=\"next\">\r\n        <span class=\"carousel-control-next-icon\" aria-hidden=\"true\"></span>\r\n        <span class=\"sr-only\">Next</span>\r\n    </a>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Piranha.Extend.Blocks.ImageGalleryBlock> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
