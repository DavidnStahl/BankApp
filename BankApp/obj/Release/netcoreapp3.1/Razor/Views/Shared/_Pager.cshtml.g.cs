#pragma checksum "C:\Users\dns20\source\repos\BankAppMVC2VG-master\BankApp\BankApp\Views\Shared\_Pager.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a1089058dbec8a6b49796afad39a6e6db068a4b3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Pager), @"mvc.1.0.view", @"/Views/Shared/_Pager.cshtml")]
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
#line 1 "C:\Users\dns20\source\repos\BankAppMVC2VG-master\BankApp\BankApp\Views\_ViewImports.cshtml"
using BankApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\dns20\source\repos\BankAppMVC2VG-master\BankApp\BankApp\Views\_ViewImports.cshtml"
using BankApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\dns20\source\repos\BankAppMVC2VG-master\BankApp\BankApp\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a1089058dbec8a6b49796afad39a6e6db068a4b3", @"/Views/Shared/_Pager.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fcf7d88263c02fe4d9954178b6fcb664508ca3fb", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Pager : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BankApp.ViewModels.PagingViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n\n");
#nullable restore
#line 4 "C:\Users\dns20\source\repos\BankAppMVC2VG-master\BankApp\BankApp\Views\Shared\_Pager.cshtml"
  
    int p = 1;

#line default
#line hidden
#nullable disable
            WriteLiteral("<nav aria-label=\"Page navigation example\">\n    <ul class=\"pagination\">\n\n");
#nullable restore
#line 10 "C:\Users\dns20\source\repos\BankAppMVC2VG-master\BankApp\BankApp\Views\Shared\_Pager.cshtml"
         if (Model.ShowPrevButton)
        {


#line default
#line hidden
#nullable disable
            WriteLiteral("        <li class=\"page-item\">\n            <a class=\"page-link\" href=\"#\" aria-label=\"Previous\"");
            BeginWriteAttribute("onclick", " onclick=\"", 276, "\"", 388, 4);
            WriteAttributeValue("", 286, "window.location.href=updateQueryStringParameter(window.location.href,\'page\',", 286, 76, true);
            WriteAttributeValue(" ", 362, "\'", 363, 2, true);
#nullable restore
#line 14 "C:\Users\dns20\source\repos\BankAppMVC2VG-master\BankApp\BankApp\Views\Shared\_Pager.cshtml"
WriteAttributeValue("", 364, Model.CurrentPage-1, 364, 22, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 386, "\')", 386, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\n                <span aria-hidden=\"true\">Prev</span>\n            </a>\n            \n        </li>                    \n");
#nullable restore
#line 19 "C:\Users\dns20\source\repos\BankAppMVC2VG-master\BankApp\BankApp\Views\Shared\_Pager.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
#nullable restore
#line 21 "C:\Users\dns20\source\repos\BankAppMVC2VG-master\BankApp\BankApp\Views\Shared\_Pager.cshtml"
         foreach (var page in Model.GetPages)
        {       
            if (page == "...")
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li class=\"page-item disabled\">...</li>\n");
#nullable restore
#line 26 "C:\Users\dns20\source\repos\BankAppMVC2VG-master\BankApp\BankApp\Views\Shared\_Pager.cshtml"
            }
            else
            {
                p = Convert.ToInt32(page);

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li");
            BeginWriteAttribute("class", " class=\"", 790, "\"", 850, 2);
            WriteAttributeValue("", 798, "page-item", 798, 9, true);
#nullable restore
#line 30 "C:\Users\dns20\source\repos\BankAppMVC2VG-master\BankApp\BankApp\Views\Shared\_Pager.cshtml"
WriteAttributeValue("  ", 807, Model.CurrentPage == p ? "active" : "", 809, 41, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><a class=\"page-link\" href=\"#\"");
            BeginWriteAttribute("onclick", " onclick=\"", 881, "\"", 973, 4);
            WriteAttributeValue("", 891, "window.location.href=updateQueryStringParameter(window.location.href,\'page\',", 891, 76, true);
            WriteAttributeValue(" ", 967, "\'", 968, 2, true);
#nullable restore
#line 30 "C:\Users\dns20\source\repos\BankAppMVC2VG-master\BankApp\BankApp\Views\Shared\_Pager.cshtml"
WriteAttributeValue("", 969, p, 969, 2, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 971, "\')", 971, 2, true);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 30 "C:\Users\dns20\source\repos\BankAppMVC2VG-master\BankApp\BankApp\Views\Shared\_Pager.cshtml"
                                                                                                                                                                                                       Write(p);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\n");
#nullable restore
#line 31 "C:\Users\dns20\source\repos\BankAppMVC2VG-master\BankApp\BankApp\Views\Shared\_Pager.cshtml"
            }

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
#nullable restore
#line 35 "C:\Users\dns20\source\repos\BankAppMVC2VG-master\BankApp\BankApp\Views\Shared\_Pager.cshtml"
         if (Model.ShowNextButton)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li class=\"page-item\">\n                <a class=\"page-link\" href=\"#\" aria-label=\"Next\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1156, "\"", 1268, 4);
            WriteAttributeValue("", 1166, "window.location.href=updateQueryStringParameter(window.location.href,\'page\',", 1166, 76, true);
            WriteAttributeValue(" ", 1242, "\'", 1243, 2, true);
#nullable restore
#line 38 "C:\Users\dns20\source\repos\BankAppMVC2VG-master\BankApp\BankApp\Views\Shared\_Pager.cshtml"
WriteAttributeValue("", 1244, Model.CurrentPage+1, 1244, 22, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1266, "\')", 1266, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\n                    <span aria-hidden=\"true\">Next</span>\n                </a>\n            </li>\n");
#nullable restore
#line 42 "C:\Users\dns20\source\repos\BankAppMVC2VG-master\BankApp\BankApp\Views\Shared\_Pager.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </ul>\n</nav>\n\n\n\n\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BankApp.ViewModels.PagingViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
