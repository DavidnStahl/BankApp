#pragma checksum "C:\Users\dns20\Downloads\BankAppMVC2VG-master (1)\BankAppMVC2VG-master\BankApp\BankApp\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9b1f63c7a4dbae3abbdca31a16df72c6e7a89dd6"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9b1f63c7a4dbae3abbdca31a16df72c6e7a89dd6", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fcf7d88263c02fe4d9954178b6fcb664508ca3fb", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BankApp.ViewModels.Accounts.TotalCustomersAccountsAndBalanceSumForCountryViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("d-none d-sm-inline-block form-inline mr-auto ml-md-3 my-2 my-md-0 mw-100 navbar-search text-center"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "SearchOnId", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Country", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!-- Page Heading -->\n<div class=\"container-fluid\">\n    \n\n    <!-- Topbar Search -->\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9b1f63c7a4dbae3abbdca31a16df72c6e7a89dd65476", async() => {
                WriteLiteral(@"
        <div class=""input-group"">

            <input id=""search"" type=""number"" name=""searchid"" class=""form-control bg-white border-0 small"" placeholder=""customerid..."" aria-label=""Search"" aria-describedby=""basic-addon2"">
            <div class=""input-group-append"">
                <button id=""buttonsubmit"" class=""btn btn-primary"" type=""submit"">
                    <i class=""fas fa-search fa-sm""></i>
                </button>
            </div>

        </div>
        <div class=""input-group"">
            <span class=""text-danger"">");
#nullable restore
#line 19 "C:\Users\dns20\Downloads\BankAppMVC2VG-master (1)\BankAppMVC2VG-master\BankApp\BankApp\Views\Home\Index.cshtml"
                                 Write(ViewBag.Error);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\n        </div>\n\n\n\n\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
#nullable restore
#line 7 "C:\Users\dns20\Downloads\BankAppMVC2VG-master (1)\BankAppMVC2VG-master\BankApp\BankApp\Views\Home\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Antiforgery = false;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-antiforgery", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Antiforgery, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n    <br />\n    <!-- Content Row -->\n\n");
#nullable restore
#line 29 "C:\Users\dns20\Downloads\BankAppMVC2VG-master (1)\BankAppMVC2VG-master\BankApp\BankApp\Views\Home\Index.cshtml"
     foreach (var country in Model.CountryInfoList)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <div class=""row mt-3"">

            <!-- Earnings (Monthly) Card Example -->
            <div class=""col-xl-3 col-md-6 mb-4"">
                <div class=""card border-left-primary shadow h-100 py-2"">
                    <div class=""card-body"">
                        <div class=""row no-gutters align-items-center"">
                            <div class=""col mr-2"">
                                <div class=""text-xs font-weight-bold text-primary text-uppercase mb-1"">Customers ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9b1f63c7a4dbae3abbdca31a16df72c6e7a89dd69597", async() => {
                WriteLiteral("(");
#nullable restore
#line 39 "C:\Users\dns20\Downloads\BankAppMVC2VG-master (1)\BankAppMVC2VG-master\BankApp\BankApp\Views\Home\Index.cshtml"
                                                                                                                                                                                                Write(country.Country);

#line default
#line hidden
#nullable disable
                WriteLiteral(")");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-country", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 39 "C:\Users\dns20\Downloads\BankAppMVC2VG-master (1)\BankAppMVC2VG-master\BankApp\BankApp\Views\Home\Index.cshtml"
                                                                                                                                                                      WriteLiteral(country.Country);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["country"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-country", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["country"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</div>\n                                <div class=\"h5 mb-0 font-weight-bold text-gray-800\">");
#nullable restore
#line 40 "C:\Users\dns20\Downloads\BankAppMVC2VG-master (1)\BankAppMVC2VG-master\BankApp\BankApp\Views\Home\Index.cshtml"
                                                                               Write(country.NumbersOfCustomers);

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

            <!-- Earnings (Monthly) Card Example -->
            <div class=""col-xl-3 col-md-6 mb-4"">
                <div class=""card border-left-success shadow h-100 py-2"">
                    <div class=""card-body"">
                        <div class=""row no-gutters align-items-center"">
                            <div class=""col mr-2"">
                                <div class=""text-xs font-weight-bold text-success text-uppercase mb-1"">Accounts ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9b1f63c7a4dbae3abbdca31a16df72c6e7a89dd613790", async() => {
                WriteLiteral("(");
#nullable restore
#line 56 "C:\Users\dns20\Downloads\BankAppMVC2VG-master (1)\BankAppMVC2VG-master\BankApp\BankApp\Views\Home\Index.cshtml"
                                                                                                                                                                                               Write(country.Country);

#line default
#line hidden
#nullable disable
                WriteLiteral(")");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-country", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 56 "C:\Users\dns20\Downloads\BankAppMVC2VG-master (1)\BankAppMVC2VG-master\BankApp\BankApp\Views\Home\Index.cshtml"
                                                                                                                                                                     WriteLiteral(country.Country);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["country"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-country", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["country"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</div>\n                                <div class=\"h5 mb-0 font-weight-bold text-gray-800\" pattern=\"^\\$\\d{1,3}(,\\d{3})*(\\.\\d+)?$\">");
#nullable restore
#line 57 "C:\Users\dns20\Downloads\BankAppMVC2VG-master (1)\BankAppMVC2VG-master\BankApp\BankApp\Views\Home\Index.cshtml"
                                                                                                                      Write(country.NumbersOfAccounts);

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

            <!-- Earnings (Monthly) Card Example -->
            <div class=""col-xl-3 col-md-6 mb-4"">
                <div class=""card border-left-danger shadow h-100 py-2"">
                    <div class=""card-body"">
                        <div class=""row no-gutters align-items-center"">
                            <div class=""col mr-2"">
                                <div class=""text-xs font-weight-bold text-success text-uppercase mb-1"">Total Money ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9b1f63c7a4dbae3abbdca31a16df72c6e7a89dd618068", async() => {
                WriteLiteral("(");
#nullable restore
#line 73 "C:\Users\dns20\Downloads\BankAppMVC2VG-master (1)\BankAppMVC2VG-master\BankApp\BankApp\Views\Home\Index.cshtml"
                                                                                                                                                                                                  Write(country.Country);

#line default
#line hidden
#nullable disable
                WriteLiteral(")");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-country", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 73 "C:\Users\dns20\Downloads\BankAppMVC2VG-master (1)\BankAppMVC2VG-master\BankApp\BankApp\Views\Home\Index.cshtml"
                                                                                                                                                                        WriteLiteral(country.Country);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["country"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-country", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["country"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</div>\n                                <div class=\"h5 mb-0 font-weight-bold text-gray-800\">");
#nullable restore
#line 74 "C:\Users\dns20\Downloads\BankAppMVC2VG-master (1)\BankAppMVC2VG-master\BankApp\BankApp\Views\Home\Index.cshtml"
                                                                               Write(country.SumAccountBalance.ToString("C2"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
                            </div>
                            <div class=""col-auto"">
                                <i class=""fas fa-dollar-sign fa-2x text-gray-300""></i>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
");
#nullable restore
#line 84 "C:\Users\dns20\Downloads\BankAppMVC2VG-master (1)\BankAppMVC2VG-master\BankApp\BankApp\Views\Home\Index.cshtml"


    }

#line default
#line hidden
#nullable disable
            WriteLiteral("   </div>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BankApp.ViewModels.Accounts.TotalCustomersAccountsAndBalanceSumForCountryViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
