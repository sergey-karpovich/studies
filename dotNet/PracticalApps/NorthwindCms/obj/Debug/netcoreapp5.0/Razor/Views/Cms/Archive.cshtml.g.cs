#pragma checksum "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\Archive.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7f079c9b53adab8e8468e9e31ecdb3847a550000"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cms_Archive), @"mvc.1.0.view", @"/Views/Cms/Archive.cshtml")]
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
#line 2 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\Archive.cshtml"
using System.Globalization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7f079c9b53adab8e8468e9e31ecdb3847a550000", @"/Views/Cms/Archive.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"107f1184d77f80a4fa29c7df5bfcea3406f2da9c", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Cms_Archive : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<NorthwindCms.Models.BlogArchive>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\Archive.cshtml"
  
    ViewBag.Title = Model.Title;

    Func<string> BlogLink = () => {
        return Model.Permalink
            + (Model.Archive.Category != null ? $"/category/{Model.Archive.Category.Slug}"  : "")
            + (Model.Archive.Year.HasValue ? $"/{Model.Archive.Year}" : "" )
            + (Model.Archive.Month.HasValue ? $"/{Model.Archive.Month}" : "");
    };

    Func<string> MonthName = () => {
        if (Model.Archive.Month.HasValue) {
            return new DateTime(2018, Model.Archive.Month.Value, 1) .ToString("MMMM", CultureInfo.InvariantCulture);
        }
        return "";
    };

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 22 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\Archive.cshtml"
 if(TempData["import_message"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"container\">\r\n  <div class=\"row\">\r\n    <div class=\"col\">\r\n      <div class=\"alert alert-info\" role=\"alert\">\r\n        <h4 class=\"alert-heading\">Import</h4>\r\n        <p>");
#nullable restore
#line 29 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\Archive.cshtml"
      Write(TempData["import_message"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n      </div>\r\n    </div>\r\n  </div>\r\n</div>\r\n");
#nullable restore
#line 34 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\Archive.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container archive\">\r\n");
#nullable restore
#line 37 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\Archive.cshtml"
     if (Model.Archive.Category != null) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"row\">\r\n            <div class=\"col blog-filter-header\">\r\n                <h1>Category: ");
#nullable restore
#line 40 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\Archive.cshtml"
                         Write(Model.Archive.Category.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 43 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\Archive.cshtml"
    } else if (Model.Archive.Tag != null) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"row\">\r\n            <div class=\"col blog-filter-header\">\r\n                <h1>Tag: ");
#nullable restore
#line 46 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\Archive.cshtml"
                    Write(Model.Archive.Tag.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 49 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\Archive.cshtml"
    } else if (Model.Archive.Year.HasValue) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"row\">\r\n            <div class=\"col blog-filter-header\">\r\n                <h1>Posts from ");
#nullable restore
#line 52 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\Archive.cshtml"
                          Write(MonthName());

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 52 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\Archive.cshtml"
                                       Write(Model.Archive.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 55 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\Archive.cshtml"
    } else {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"row\">\r\n            <div class=\"col blog-filter-header\">\r\n                <h1>Latest posts</h1>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 61 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\Archive.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 63 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\Archive.cshtml"
     foreach (var post in Model.Archive.Posts)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <article>\r\n            <header>\r\n");
#nullable restore
#line 67 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\Archive.cshtml"
                 if (post.Regions.Hero.PrimaryImage.HasValue)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <a");
            BeginWriteAttribute("href", " href=\"", 2095, "\"", 2117, 1);
#nullable restore
#line 69 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\Archive.cshtml"
WriteAttributeValue("", 2102, post.Permalink, 2102, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><img");
            BeginWriteAttribute("src", " src=\"", 2123, "\"", 2195, 1);
#nullable restore
#line 69 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\Archive.cshtml"
WriteAttributeValue("", 2129, Url.Content(post.Regions.Hero.PrimaryImage.Resize(Api, 930, 360)), 2129, 66, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></a>\r\n");
#nullable restore
#line 70 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\Archive.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                <h2><a");
            BeginWriteAttribute("href", " href=\"", 2244, "\"", 2266, 1);
#nullable restore
#line 71 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\Archive.cshtml"
WriteAttributeValue("", 2251, post.Permalink, 2251, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 71 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\Archive.cshtml"
                                         Write(post.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></h2>\r\n                <p class=\"post-meta\">\r\n                    <strong>In</strong> <a");
            BeginWriteAttribute("href", " href=\"", 2371, "\"", 2423, 3);
#nullable restore
#line 73 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\Archive.cshtml"
WriteAttributeValue("", 2378, Model.Permalink, 2378, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2394, "/category/", 2394, 10, true);
#nullable restore
#line 73 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\Archive.cshtml"
WriteAttributeValue("", 2404, post.Category.Slug, 2404, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 73 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\Archive.cshtml"
                                                                                           Write(post.Category.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                    <span class=\"sep\">&#9670;</span>\r\n                    <strong>Tags</strong>\r\n");
#nullable restore
#line 76 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\Archive.cshtml"
                     foreach (var tag in post.Tags)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span class=\"tag\"><a");
            BeginWriteAttribute("href", " href=\"", 2668, "\"", 2705, 3);
#nullable restore
#line 78 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\Archive.cshtml"
WriteAttributeValue("", 2675, Model.Permalink, 2675, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2691, "/tag/", 2691, 5, true);
#nullable restore
#line 78 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\Archive.cshtml"
WriteAttributeValue("", 2696, tag.Slug, 2696, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">#");
#nullable restore
#line 78 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\Archive.cshtml"
                                                                               Write(tag.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></span>\r\n");
#nullable restore
#line 79 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\Archive.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <span class=\"sep\">&#9670;</span>\r\n                    <strong>Published</strong>\r\n                    ");
#nullable restore
#line 82 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\Archive.cshtml"
               Write(post.Published.Value.ToString("yyyy-MM-dd"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </p>\r\n            </header>\r\n            <div class=\"ingress\">\r\n                ");
#nullable restore
#line 86 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\Archive.cshtml"
           Write(Html.Raw(post.Regions.Hero.Ingress));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <p><a class=\"btn btn-link\"");
            BeginWriteAttribute("href", " href=\"", 3114, "\"", 3136, 1);
#nullable restore
#line 88 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\Archive.cshtml"
WriteAttributeValue("", 3121, post.Permalink, 3121, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Read more</a></p>\r\n        </article>\r\n");
#nullable restore
#line 90 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\Archive.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 91 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\Archive.cshtml"
     if (Model.Archive.TotalPages > 1) {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <div class=""row"">
            <div class=""col"">
                <nav aria-label=""Page navigation example"">
                <ul class=""pagination justify-content-center"">
                    <li class=""page-item"">
                        <a class=""page-link""");
            BeginWriteAttribute("href", " href=\"", 3496, "\"", 3521, 2);
#nullable restore
#line 97 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\Archive.cshtml"
WriteAttributeValue("", 3503, BlogLink(), 3503, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3514, "/page/1", 3514, 7, true);
            EndWriteAttribute();
            WriteLiteral(@">
                            <span aria-hidden=""true"">&laquo;</span>
                            <span class=""sr-only"">Previous</span>
                        </a>
                    </li>
                    <li class=""page-item"">
                        <a class=""page-link""");
            BeginWriteAttribute("href", " href=\"", 3806, "\"", 3873, 3);
#nullable restore
#line 103 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\Archive.cshtml"
WriteAttributeValue("", 3813, BlogLink(), 3813, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3824, "/page/", 3824, 6, true);
#nullable restore
#line 103 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\Archive.cshtml"
WriteAttributeValue("", 3830, Math.Max(1, Model.Archive.CurrentPage - 1), 3830, 43, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                            <span aria-hidden=\"true\">&lsaquo;</span>\r\n                            <span class=\"sr-only\">Previous</span>\r\n                        </a>\r\n                    </li>\r\n");
#nullable restore
#line 108 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\Archive.cshtml"
                     for (var n = 1; n <= Model.Archive.TotalPages; n++) {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li");
            BeginWriteAttribute("class", " class=\"", 4174, "\"", 4241, 2);
            WriteAttributeValue("", 4182, "page-item", 4182, 9, true);
#nullable restore
#line 109 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\Archive.cshtml"
WriteAttributeValue(" ", 4191, Model.Archive.CurrentPage == n ? "active" : "", 4192, 49, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 4263, "\"", 4289, 3);
#nullable restore
#line 109 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\Archive.cshtml"
WriteAttributeValue("", 4270, BlogLink(), 4270, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4281, "/page/", 4281, 6, true);
#nullable restore
#line 109 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\Archive.cshtml"
WriteAttributeValue("", 4287, n, 4287, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 109 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\Archive.cshtml"
                                                                                                                                           Write(n);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 110 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\Archive.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li class=\"page-item\">\r\n                        <a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 4415, "\"", 4505, 3);
#nullable restore
#line 112 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\Archive.cshtml"
WriteAttributeValue("", 4422, BlogLink(), 4422, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4433, "/page/", 4433, 6, true);
#nullable restore
#line 112 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\Archive.cshtml"
WriteAttributeValue("", 4439, Math.Min(Model.Archive.TotalPages, Model.Archive.CurrentPage + 1), 4439, 66, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                            <span aria-hidden=""true"">&rsaquo;</span>
                            <span class=""sr-only"">Next</span>
                        </a>
                    </li>
                    <li class=""page-item"">
                        <a class=""page-link""");
            BeginWriteAttribute("href", " href=\"", 4787, "\"", 4836, 3);
#nullable restore
#line 118 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\Archive.cshtml"
WriteAttributeValue("", 4794, BlogLink(), 4794, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4805, "/page/", 4805, 6, true);
#nullable restore
#line 118 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\Archive.cshtml"
WriteAttributeValue("", 4811, Model.Archive.TotalPages, 4811, 25, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                            <span aria-hidden=""true"">&raquo;</span>
                            <span class=""sr-only"">Next</span>
                        </a>
                    </li>
                </ul>
                </nav>
            </div>
        </div>
");
#nullable restore
#line 127 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\Archive.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Piranha.IApi Api { get; private set; } = default!;
        #nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<NorthwindCms.Models.BlogArchive> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
