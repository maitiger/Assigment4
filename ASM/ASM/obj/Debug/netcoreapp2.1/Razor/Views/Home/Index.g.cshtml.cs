#pragma checksum "D:\Cac Thu Cac Thu\ProjectNhom4\Assigment4\ASM\ASM\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cda96695344a76a7ce751fffdbcc33343b43386b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "D:\Cac Thu Cac Thu\ProjectNhom4\Assigment4\ASM\ASM\Views\_ViewImports.cshtml"
using ASM;

#line default
#line hidden
#line 3 "D:\Cac Thu Cac Thu\ProjectNhom4\Assigment4\ASM\ASM\Views\Home\Index.cshtml"
using ASM.Models;

#line default
#line hidden
#line 2 "D:\Cac Thu Cac Thu\ProjectNhom4\Assigment4\ASM\ASM\Views\Home\Index.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cda96695344a76a7ce751fffdbcc33343b43386b", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"de453dc6ef1879827b9c87cbe9f0cf8e206f5ca6", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("account"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(59, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(159, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 8 "D:\Cac Thu Cac Thu\ProjectNhom4\Assigment4\ASM\ASM\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Đăng Nhập";

#line default
#line hidden
            BeginContext(206, 639, true);
            WriteLiteral(@"<div class=""content"">
        <ul class=""ca-menu"" style=""margin-top: 104px;"">
            <center>
                <li style=""list-style:none;"">
                    <button onclick=""myFunction()"">
                        <span class=""ca-icon"">Đăng Nhập</span>
                        <div class=""ca-content"">
                            <h3 class=""ca-sub"">Đăng Nhập Vào Tài Khoản Của Bạn</h3>
                        </div>
                    </button>
                </li>
            </center>

        </ul>
        
</div><!-- content -->
<br />
<div id=""Login"" style=""display: none;""> <!-- đặt mặc định ẩn--> 
    ");
            EndContext();
            BeginContext(845, 2287, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "464ddc47d5e345d6a4976cdf05fb9225", async() => {
                BeginContext(879, 2246, true);
                WriteLiteral(@"
        <h4>Use a local account to log in.</h4>
        <hr>
        <div class=""text-danger validation-summary-valid"" data-valmsg-summary=""true"">
            <ul>
                <li style=""display:none""></li>
            </ul>
        </div>
        <div class=""form-group"">
            <label for=""Input_Email"">Email</label>
            <input class=""form-control"" type=""email"" data-val=""true"" data-val-email=""The Email field is not a valid e-mail address."" data-val-required=""The Email field is required."" id=""Input_Email"" name=""Input.Email"" value="""">
            <span class=""text-danger field-validation-valid"" data-valmsg-for=""Input.Email"" data-valmsg-replace=""true""></span>
        </div>
        <div class=""form-group"">
            <label for=""Input_Password"">Password</label>
            <input class=""form-control"" type=""password"" data-val=""true"" data-val-required=""The Password field is required."" id=""Input_Password"" name=""Input.Password"">
            <span class=""text-danger field-validation");
                WriteLiteral(@"-valid"" data-valmsg-for=""Input.Password"" data-valmsg-replace=""true""></span>
        </div>
        <div class=""form-group"">
            <div class=""checkbox"">
                <label for=""Input_RememberMe"">
                    <input type=""checkbox"" data-val=""true"" data-val-required=""The Remember me? field is required."" id=""Input_RememberMe"" name=""Input.RememberMe"" value=""true"">
                    Remember me?
                </label>
            </div>
        </div>
        <div class=""form-group"">
            <button type=""submit"" class=""btn btn-default"">Log in</button>
        </div>
        <div class=""form-group"">
            <p>
                <a id=""forgot-password"" href=""/Identity/Account/ForgotPassword"">Forgot your password?</a>
            </p>
            <p>
                <a href=""/Identity/Account/Register?returnUrl=%2F"">Register as a new user</a>
            </p>
        </div>
        <input name=""__RequestVerificationToken"" type=""hidden"" value=""CfDJ8KqYs2KVxzBBunHe6UWC");
                WriteLiteral("r2k5P7qbyoCPc3KrWVow88ese_NJAqtGiAL3qqQSXYpUAvVcgwrqMUXDC4FXyABkuUmFqkrlF5LLlVym3yfVJuPdCJ1la9TvJ6-GeKIAJOjZgLKbmplYEsAsiGv_LYMnCsQ\"><input name=\"Input.RememberMe\" type=\"hidden\" value=\"false\">\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3132, 12, true);
            WriteLiteral("\r\n</div>\r\n\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<IdentityUser> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<IdentityUser> SignInManager { get; private set; }
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
