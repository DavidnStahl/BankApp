#pragma checksum "C:\Users\dns20\Downloads\BankAppMVC2VG-master (1)\BankAppMVC2VG-master\BankApp\BankApp\Views\Customer\ViewTransactions.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "90c00f469c9356bb590449a345c61960e8146d6b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Customer_ViewTransactions), @"mvc.1.0.view", @"/Views/Customer/ViewTransactions.cshtml")]
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
#line 1 "C:\Users\dns20\Downloads\BankAppMVC2VG-master (1)\BankAppMVC2VG-master\BankApp\BankApp\Views\_ViewImports.cshtml"
using BankApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\dns20\Downloads\BankAppMVC2VG-master (1)\BankAppMVC2VG-master\BankApp\BankApp\Views\_ViewImports.cshtml"
using BankApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\dns20\Downloads\BankAppMVC2VG-master (1)\BankAppMVC2VG-master\BankApp\BankApp\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"90c00f469c9356bb590449a345c61960e8146d6b", @"/Views/Customer/ViewTransactions.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fcf7d88263c02fe4d9954178b6fcb664508ca3fb", @"/Views/_ViewImports.cshtml")]
    public class Views_Customer_ViewTransactions : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BankApp.ViewModels.Accounts.AccountInformationViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "C:\Users\dns20\Downloads\BankAppMVC2VG-master (1)\BankAppMVC2VG-master\BankApp\BankApp\Views\Customer\ViewTransactions.cshtml"
   
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    <div class=""container"">

        <!-- Earnings (Monthly) Card Example -->
        <div class=""col-xl-6 col-md-6 mb-4"">
            <div class=""card border-left-primary shadow h-100 py-2"">
                <div class=""card-body"">
                    <div class=""row no-gutters align-items-center"">
                        <div class=""col mr-6"">
                            <div class=""text-xl-left font-weight-bold text-primary text-uppercase mb-1"">Transactions</div>
                            <div class=""text-xl-left font-weight-bold text-primary text-uppercase mb-1"">AccountId: ");
#nullable restore
#line 16 "C:\Users\dns20\Downloads\BankAppMVC2VG-master (1)\BankAppMVC2VG-master\BankApp\BankApp\Views\Customer\ViewTransactions.cshtml"
                                                                                                              Write(Model.AccountId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n                            <div class=\"text-xl-left  font-weight-bold text-primary text-uppercase mb-1\">Balance: ");
#nullable restore
#line 17 "C:\Users\dns20\Downloads\BankAppMVC2VG-master (1)\BankAppMVC2VG-master\BankApp\BankApp\Views\Customer\ViewTransactions.cshtml"
                                                                                                             Write(Model.Balance.ToString("C2"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
                        </div>
                        <div class=""col-auto"">
                            <i class=""fas fa-calendar fa-2x text-gray-300""></i>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
        <div class=""container"">
            <div class=""row"">
                <!-- Earnings (Monthly) Card Example -->
                <div class=""col-xl-12 col-md-5 mb-4 text-center"">
                    <div class=""card border-left-primary shadow h-100 py-2"">
                        <div class=""card-body text-primary"">
                            <div class=""row no-gutters align-items-center"">
                                <div class=""col mr-auto"">

                                    <div id=""partialview"">
                                        ");
#nullable restore
#line 38 "C:\Users\dns20\Downloads\BankAppMVC2VG-master (1)\BankAppMVC2VG-master\BankApp\BankApp\Views\Customer\ViewTransactions.cshtml"
                                   Write(await Html.PartialAsync("_Transactions", Model));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                    </div>\n                                </div>\n                            </div>\n                        </div>\n                    </div>\n                </div>\n            </div>\n        </div>\n\n\n\n\n\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BankApp.ViewModels.Accounts.AccountInformationViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
