#pragma checksum "C:\Users\User\Desktop\Tatyrkova.Eshop.Web\Tatyrkova.Eshop.Web\Views\Product\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b77e68f1880b1576b6845b6344c054b249766665"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_Detail), @"mvc.1.0.view", @"/Views/Product/Detail.cshtml")]
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
#line 1 "C:\Users\User\Desktop\Tatyrkova.Eshop.Web\Tatyrkova.Eshop.Web\Views\_ViewImports.cshtml"
using Tatyrkova.Eshop.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\Desktop\Tatyrkova.Eshop.Web\Tatyrkova.Eshop.Web\Views\_ViewImports.cshtml"
using Tatyrkova.Eshop.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\User\Desktop\Tatyrkova.Eshop.Web\Tatyrkova.Eshop.Web\Views\_ViewImports.cshtml"
using Tatyrkova.Eshop.Web.Models.Entity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\User\Desktop\Tatyrkova.Eshop.Web\Tatyrkova.Eshop.Web\Views\_ViewImports.cshtml"
using Tatyrkova.Eshop.Web.Models.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\User\Desktop\Tatyrkova.Eshop.Web\Tatyrkova.Eshop.Web\Views\_ViewImports.cshtml"
using Tatyrkova.Eshop.Web.Models.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b77e68f1880b1576b6845b6344c054b249766665", @"/Views/Product/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e2554a823796a312d080ffaed7c45256ea3f5635", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Product>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/shop_item.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            DefineSection("Styles", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "b77e68f1880b1576b6845b6344c054b2497666654553", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\User\Desktop\Tatyrkova.Eshop.Web\Tatyrkova.Eshop.Web\Views\Product\Detail.cshtml"
   
    if(Model != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("<section class=\"py-5\">\r\n    <div class=\"container px-4 px-lg-5 my-5\">\r\n        <div class=\"row gx-4 gx-lg-5 align-items-center\">\r\n            <div class=\"col-md-6\"><img class=\"card-img-top mb-5 mb-md-0\"");
            BeginWriteAttribute("src", " src=\"", 344, "\"", 368, 1);
#nullable restore
#line 13 "C:\Users\User\Desktop\Tatyrkova.Eshop.Web\Tatyrkova.Eshop.Web\Views\Product\Detail.cshtml"
WriteAttributeValue("", 350, Model.ImageSource, 350, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 369, "\"", 390, 1);
#nullable restore
#line 13 "C:\Users\User\Desktop\Tatyrkova.Eshop.Web\Tatyrkova.Eshop.Web\Views\Product\Detail.cshtml"
WriteAttributeValue("", 375, Model.ImageAlt, 375, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" /></div>\r\n            <div class=\"col-md-6\">\r\n                <div class=\"small mb-1\">");
#nullable restore
#line 15 "C:\Users\User\Desktop\Tatyrkova.Eshop.Web\Tatyrkova.Eshop.Web\Views\Product\Detail.cshtml"
                                   Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                <!--<h1 class=\"display-5 fw-bolder\">Shop item template</h1>-->\r\n                <div class=\"fs-5 mb-5\">\r\n                    <span>");
#nullable restore
#line 18 "C:\Users\User\Desktop\Tatyrkova.Eshop.Web\Tatyrkova.Eshop.Web\Views\Product\Detail.cshtml"
                     Write(Model.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" K??</span>\r\n                </div>\r\n                <p class=\"lead\">");
#nullable restore
#line 20 "C:\Users\User\Desktop\Tatyrkova.Eshop.Web\Tatyrkova.Eshop.Web\Views\Product\Detail.cshtml"
                           Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                <div class=""d-flex"">
                    <input class=""form-control text-center me-3"" id=""inputQuantity"" type=""number"" value=""1"" style=""max-width: 3rem"" />
                    <button class=""btn btn-outline-dark flex-shrink-0"" type=""button"">
                        <i class=""bi-cart-fill me-1""></i>
                        Add to cart
                    </button>
                </div>
            </div>
        </div>
    </div>
</section>
");
#nullable restore
#line 32 "C:\Users\User\Desktop\Tatyrkova.Eshop.Web\Tatyrkova.Eshop.Web\Views\Product\Detail.cshtml"
            }

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Product> Html { get; private set; }
    }
}
#pragma warning restore 1591
