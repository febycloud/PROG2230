#pragma checksum "C:\Users\Fei\Desktop\PROG2230\musicstore\musicstore\Views\Test\PriceChange.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dda483df06c720af9a9dfc297dbb1284f39b418b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Test_PriceChange), @"mvc.1.0.view", @"/Views/Test/PriceChange.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Test/PriceChange.cshtml", typeof(AspNetCore.Views_Test_PriceChange))]
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
#line 1 "C:\Users\Fei\Desktop\PROG2230\musicstore\musicstore\Views\_ViewImports.cshtml"
using musicstore;

#line default
#line hidden
#line 2 "C:\Users\Fei\Desktop\PROG2230\musicstore\musicstore\Views\_ViewImports.cshtml"
using musicstore.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dda483df06c720af9a9dfc297dbb1284f39b418b", @"/Views/Test/PriceChange.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f8476b7a92ec51594cf6cb82c626102379c098b2", @"/Views/_ViewImports.cshtml")]
    public class Views_Test_PriceChange : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("=text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\Fei\Desktop\PROG2230\musicstore\musicstore\Views\Test\PriceChange.cshtml"
  
    ViewData["Title"] = "PriceChange";

#line default
#line hidden
            BeginContext(49, 118, true);
            WriteLiteral("\r\n<h1>PriceChange</h1>\r\n\r\n// all is show all tyoe of errors\r\n//modelonly show the error of models which key is blank\r\n");
            EndContext();
            BeginContext(167, 67, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dda483df06c720af9a9dfc297dbb1284f39b418b3972", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#line 10 "C:\Users\Fei\Desktop\PROG2230\musicstore\musicstore\Views\Test\PriceChange.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary = global::Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.ModelOnly;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-summary", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(234, 118, true);
            WriteLiteral("\r\n<table>\r\n    <tr>\r\n\r\n        <th>Title</th>\r\n       \r\n        <th>Price</th>\r\n        <th>taxPrice</th>\r\n    </tr>\r\n");
            EndContext();
#line 19 "C:\Users\Fei\Desktop\PROG2230\musicstore\musicstore\Views\Test\PriceChange.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
            BeginContext(393, 16, true);
            WriteLiteral("<tr>\r\n\r\n    <td>");
            EndContext();
            BeginContext(410, 10, false);
#line 23 "C:\Users\Fei\Desktop\PROG2230\musicstore\musicstore\Views\Test\PriceChange.cshtml"
   Write(item.Title);

#line default
#line hidden
            EndContext();
            BeginContext(420, 21, true);
            WriteLiteral("</td>\r\n    \r\n    <td>");
            EndContext();
            BeginContext(442, 25, false);
#line 25 "C:\Users\Fei\Desktop\PROG2230\musicstore\musicstore\Views\Test\PriceChange.cshtml"
   Write(item.Price.ToString("C2"));

#line default
#line hidden
            EndContext();
            BeginContext(467, 15, true);
            WriteLiteral("</td>\r\n    <td>");
            EndContext();
            BeginContext(483, 13, false);
#line 26 "C:\Users\Fei\Desktop\PROG2230\musicstore\musicstore\Views\Test\PriceChange.cshtml"
   Write(item.taxPrice);

#line default
#line hidden
            EndContext();
            BeginContext(496, 14, true);
            WriteLiteral("</td>\r\n</tr>\r\n");
            EndContext();
#line 28 "C:\Users\Fei\Desktop\PROG2230\musicstore\musicstore\Views\Test\PriceChange.cshtml"
    }

#line default
#line hidden
            BeginContext(517, 14, true);
            WriteLiteral("    </table>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
