#pragma checksum "C:\Users\Fei\Desktop\PROG2230\musicstore\musicstore\Views\Test\FilterView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "185a4e33d670f7a9ee6adfe11a80cef4438cc47a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Test_FilterView), @"mvc.1.0.view", @"/Views/Test/FilterView.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Test/FilterView.cshtml", typeof(AspNetCore.Views_Test_FilterView))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"185a4e33d670f7a9ee6adfe11a80cef4438cc47a", @"/Views/Test/FilterView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f8476b7a92ec51594cf6cb82c626102379c098b2", @"/Views/_ViewImports.cshtml")]
    public class Views_Test_FilterView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
#line 2 "C:\Users\Fei\Desktop\PROG2230\musicstore\musicstore\Views\Test\FilterView.cshtml"
  
    ViewData["Title"] = "FilterView";

#line default
#line hidden
            BeginContext(48, 117, true);
            WriteLiteral("\r\n<h1>FilterView</h1>\r\n\r\n// all is show all tyoe of errors\r\n//modelonly show the error of models which key is blank\r\n");
            EndContext();
            BeginContext(165, 67, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "185a4e33d670f7a9ee6adfe11a80cef4438cc47a3962", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#line 10 "C:\Users\Fei\Desktop\PROG2230\musicstore\musicstore\Views\Test\FilterView.cshtml"
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
            BeginContext(232, 123, true);
            WriteLiteral("\r\n<table>\r\n    <tr>\r\n        \r\n        <th>Title</th>\r\n        <th>Artist</th>\r\n        <th>Generes</th>      \r\n    </tr>\r\n");
            EndContext();
#line 18 "C:\Users\Fei\Desktop\PROG2230\musicstore\musicstore\Views\Test\FilterView.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
            BeginContext(396, 44, true);
            WriteLiteral("        <tr>\r\n            \r\n            <td>");
            EndContext();
            BeginContext(441, 10, false);
#line 22 "C:\Users\Fei\Desktop\PROG2230\musicstore\musicstore\Views\Test\FilterView.cshtml"
           Write(item.Title);

#line default
#line hidden
            EndContext();
            BeginContext(451, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(475, 16, false);
#line 23 "C:\Users\Fei\Desktop\PROG2230\musicstore\musicstore\Views\Test\FilterView.cshtml"
           Write(item.Artist.Name);

#line default
#line hidden
            EndContext();
            BeginContext(491, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(515, 15, false);
#line 24 "C:\Users\Fei\Desktop\PROG2230\musicstore\musicstore\Views\Test\FilterView.cshtml"
           Write(item.Genre.Name);

#line default
#line hidden
            EndContext();
            BeginContext(530, 36, true);
            WriteLiteral("</td>\r\n            \r\n        </tr>\r\n");
            EndContext();
#line 27 "C:\Users\Fei\Desktop\PROG2230\musicstore\musicstore\Views\Test\FilterView.cshtml"
    }

#line default
#line hidden
            BeginContext(573, 12, true);
            WriteLiteral("</table>\r\n\r\n");
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
