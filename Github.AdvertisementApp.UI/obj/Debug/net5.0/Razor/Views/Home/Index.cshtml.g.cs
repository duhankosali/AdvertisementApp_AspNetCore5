#pragma checksum "D:\Github\AdvertisementApp_AspNetCore5\Github.AdvertisementApp.UI\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6354703b9c721f493d073004be472a2038e68e2b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 2 "D:\Github\AdvertisementApp_AspNetCore5\Github.AdvertisementApp.UI\Views\_ViewImports.cshtml"
using Github.AdvertisementApp.Dtos;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6354703b9c721f493d073004be472a2038e68e2b", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3df3d508f9a9c7299a482297496b2038cdcaa03f", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ProvidedServiceListDto>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 5 "D:\Github\AdvertisementApp_AspNetCore5\Github.AdvertisementApp.UI\Views\Home\Index.cshtml"
  
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<!-- Header-->
        <header class=""masthead text-center text-white"">
            <div class=""masthead-content"">
                <div class=""container px-5"">
                    <h1 class=""masthead-heading mb-0"">Github Bilişim</h1>
                    <h2 class=""masthead-subheading mb-0"">Desktop, Web and Mobile applications</h2>
                    <a class=""btn btn-primary btn-xl rounded-pill mt-5"" href=""#scroll"">Learn More</a>
                </div>
            </div>
            <div class=""bg-circle-1 bg-circle""></div>
            <div class=""bg-circle-2 bg-circle""></div>
            <div class=""bg-circle-3 bg-circle""></div>
            <div class=""bg-circle-4 bg-circle""></div>
        </header>
");
#nullable restore
#line 22 "D:\Github\AdvertisementApp_AspNetCore5\Github.AdvertisementApp.UI\Views\Home\Index.cshtml"
 for(int i=0; i<Model?.Count; i++)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <section id=\"scroll\">\r\n        <div class=\"container px-5\">\r\n            <div class=\"row gx-5 align-items-center\">\r\n                <div");
            BeginWriteAttribute("class", " class=\"", 1096, "\"", 1139, 3);
            WriteAttributeValue("", 1104, "col-lg-6", 1104, 8, true);
#nullable restore
#line 27 "D:\Github\AdvertisementApp_AspNetCore5\Github.AdvertisementApp.UI\Views\Home\Index.cshtml"
WriteAttributeValue(" ", 1112, i%2==0?"order-lg-2":"", 1113, 25, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 1138, "", 1139, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <div class=\"p-5\"><img class=\"img-fluid rounded-circle\"");
            BeginWriteAttribute("src", " src=\"", 1217, "\"", 1243, 2);
            WriteAttributeValue("", 1223, "~", 1223, 1, true);
#nullable restore
#line 28 "D:\Github\AdvertisementApp_AspNetCore5\Github.AdvertisementApp.UI\Views\Home\Index.cshtml"
WriteAttributeValue("", 1224, Model[i].ImagePath, 1224, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"...\" /></div>\r\n                </div>\r\n                <div");
            BeginWriteAttribute("class", " class=\"", 1309, "\"", 1352, 3);
            WriteAttributeValue("", 1317, "col-lg-6", 1317, 8, true);
#nullable restore
#line 30 "D:\Github\AdvertisementApp_AspNetCore5\Github.AdvertisementApp.UI\Views\Home\Index.cshtml"
WriteAttributeValue(" ", 1325, i%2==0?"order-lg-1":"", 1326, 25, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 1351, "", 1352, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <div class=\"p-5\">\r\n                        <h2 class=\"display-4\">");
#nullable restore
#line 32 "D:\Github\AdvertisementApp_AspNetCore5\Github.AdvertisementApp.UI\Views\Home\Index.cshtml"
                                         Write(Model[i].Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                        <p>");
#nullable restore
#line 33 "D:\Github\AdvertisementApp_AspNetCore5\Github.AdvertisementApp.UI\Views\Home\Index.cshtml"
                      Write(Model[i].Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n</section>\r\n");
#nullable restore
#line 39 "D:\Github\AdvertisementApp_AspNetCore5\Github.AdvertisementApp.UI\Views\Home\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
        }
        #pragma warning restore 1998
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ProvidedServiceListDto>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
