#pragma checksum "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\DisplayTemplates\YouTubeBlock.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e020b4b206d2aa3034ff5458bc30c8fdf3fd4a66"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cms_DisplayTemplates_YouTubeBlock), @"mvc.1.0.view", @"/Views/Cms/DisplayTemplates/YouTubeBlock.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e020b4b206d2aa3034ff5458bc30c8fdf3fd4a66", @"/Views/Cms/DisplayTemplates/YouTubeBlock.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"107f1184d77f80a4fa29c7df5bfcea3406f2da9c", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Cms_DisplayTemplates_YouTubeBlock : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<NorthwindCms.Models.Blocks.YouTubeBlock>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\DisplayTemplates\YouTubeBlock.cshtml"
  
  string allowfullscreen = string.Empty;
  string autoplay = string.Empty;
  string start = string.Empty;

  if (Model.AllowFullscreen)
  {
    allowfullscreen = "allowfullscreen";
  }

  if (Model.Autoplay)
  {
    autoplay = "&autoplay=1";
  }

  if (Model.Start > 0)
  {
    autoplay = "&start=" + Model.Start;
  }

#line default
#line hidden
#nullable disable
            WriteLiteral("<iframe");
            BeginWriteAttribute("width", " width=\"", 398, "\"", 418, 1);
#nullable restore
#line 22 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\DisplayTemplates\YouTubeBlock.cshtml"
WriteAttributeValue("", 406, Model.Width, 406, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("height", " height=\"", 419, "\"", 441, 1);
#nullable restore
#line 22 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\DisplayTemplates\YouTubeBlock.cshtml"
WriteAttributeValue("", 428, Model.Height, 428, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" frameborder=\"0\" ");
#nullable restore
#line 22 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\DisplayTemplates\YouTubeBlock.cshtml"
                                                               Write(allowfullscreen);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n  src=\"https://www.youtube.com/embed/");
#nullable restore
#line 23 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\DisplayTemplates\YouTubeBlock.cshtml"
                                 Write(Model.VideoID);

#line default
#line hidden
#nullable disable
            WriteLiteral("?");
#nullable restore
#line 23 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\DisplayTemplates\YouTubeBlock.cshtml"
                                                  Write(autoplay);

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "C:\git\projects\PriceLessons\PracticalApps\NorthwindCms\Views\Cms\DisplayTemplates\YouTubeBlock.cshtml"
                                                             Write(start);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n</iframe>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<NorthwindCms.Models.Blocks.YouTubeBlock> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
