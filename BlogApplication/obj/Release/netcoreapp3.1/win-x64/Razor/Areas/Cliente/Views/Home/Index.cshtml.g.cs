#pragma checksum "F:\Developments\NetCore\BlogApplication\BlogApplication\Areas\Cliente\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "17841706c173dade1eedc192463319570eadf6e2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Cliente_Views_Home_Index), @"mvc.1.0.view", @"/Areas/Cliente/Views/Home/Index.cshtml")]
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
#line 1 "F:\Developments\NetCore\BlogApplication\BlogApplication\Areas\Cliente\Views\_ViewImports.cshtml"
using BlogApplication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\Developments\NetCore\BlogApplication\BlogApplication\Areas\Cliente\Views\_ViewImports.cshtml"
using BlogApplication.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"17841706c173dade1eedc192463319570eadf6e2", @"/Areas/Cliente/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6bc16d844003408fa6783bc55a96e3e396a7ff0b", @"/Areas/Cliente/Views/_ViewImports.cshtml")]
    public class Areas_Cliente_Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BlogApplication.Modelos.ViewModels.HomeViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("border-radius: 2px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "F:\Developments\NetCore\BlogApplication\BlogApplication\Areas\Cliente\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("\r\n    <header>\r\n    <div id=\"carouselExampleIndicators\" class=\"carousel slide\" data-ride=\"carousel\">\r\n        <div class=\"carousel-inner\">\r\n");
#nullable restore
#line 11 "F:\Developments\NetCore\BlogApplication\BlogApplication\Areas\Cliente\Views\Home\Index.cshtml"
               int cont = 0; 

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "F:\Developments\NetCore\BlogApplication\BlogApplication\Areas\Cliente\Views\Home\Index.cshtml"
             foreach (var item in Model.Slider)
            {
                var itemDinamico = cont++ == 0 ? "item active" : "item";


#line default
#line hidden
#nullable disable
            WriteLiteral("                <div");
            BeginWriteAttribute("class", " class=\"", 448, "\"", 483, 2);
            WriteAttributeValue("", 456, "carousel-item", 456, 13, true);
#nullable restore
#line 16 "F:\Developments\NetCore\BlogApplication\BlogApplication\Areas\Cliente\Views\Home\Index.cshtml"
WriteAttributeValue(" ", 469, itemDinamico, 470, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <img");
            BeginWriteAttribute("src", " src=\"", 511, "\"", 545, 1);
#nullable restore
#line 17 "F:\Developments\NetCore\BlogApplication\BlogApplication\Areas\Cliente\Views\Home\Index.cshtml"
WriteAttributeValue("", 517, Url.Content(item.UrlImagen), 517, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                    <h1 class=\"text-dark text-center\">");
#nullable restore
#line 18 "F:\Developments\NetCore\BlogApplication\BlogApplication\Areas\Cliente\Views\Home\Index.cshtml"
                                                 Write(Html.Raw(@item.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n                </div>\r\n");
#nullable restore
#line 20 "F:\Developments\NetCore\BlogApplication\BlogApplication\Areas\Cliente\Views\Home\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </div>
        <a class=""carousel-control-prev"" href=""#carouselExampleIndicators"" role=""button"" data-slide=""prev"">
            <span class=""carousel-control-prev-icon"" aria-hidden=""true""></span>
            <span class=""sr-only"">Previous</span>
        </a>
        <a class=""carousel-control-next"" href=""#carouselExampleIndicators"" role=""button"" data-slide=""next"">
            <span class=""carousel-control-next-icon"" aria-hidden=""true""></span>
            <span class=""sr-only"">Next</span>
        </a>
    </div>
    </header>

    <div class=""row fondoTitulo mt-2"">
        <div class=""col-sm-12 py-5"">
            <h1 class=""text-center text-white"">Ultimos Cursos</h1>
        </div>
    </div>

");
#nullable restore
#line 40 "F:\Developments\NetCore\BlogApplication\BlogApplication\Areas\Cliente\Views\Home\Index.cshtml"
 if (Model.ListaArticulos.Count() > 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <hr />\r\n    <div class=\"row\">\r\n");
#nullable restore
#line 44 "F:\Developments\NetCore\BlogApplication\BlogApplication\Areas\Cliente\Views\Home\Index.cshtml"
         foreach (var articulo in Model.ListaArticulos.OrderBy(o => o.Id))
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col-4\">\r\n                <div class=\"card\">\r\n                    <img");
            BeginWriteAttribute("src", " src=\"", 1674, "\"", 1699, 1);
#nullable restore
#line 48 "F:\Developments\NetCore\BlogApplication\BlogApplication\Areas\Cliente\Views\Home\Index.cshtml"
WriteAttributeValue("", 1680, articulo.UrlImagen, 1680, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"img-thumbnail\" width=\"100%\" />\r\n                    <div class=\"card-body\">\r\n                        <h5 class=\"text-center\">");
#nullable restore
#line 50 "F:\Developments\NetCore\BlogApplication\BlogApplication\Areas\Cliente\Views\Home\Index.cshtml"
                                           Write(articulo.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                        <p>");
#nullable restore
#line 51 "F:\Developments\NetCore\BlogApplication\BlogApplication\Areas\Cliente\Views\Home\Index.cshtml"
                      Write(articulo.FechaCreacion);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "17841706c173dade1eedc192463319570eadf6e29269", async() => {
                WriteLiteral("Mas Informacion..");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 52 "F:\Developments\NetCore\BlogApplication\BlogApplication\Areas\Cliente\Views\Home\Index.cshtml"
                                                                                                     WriteLiteral(articulo.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 56 "F:\Developments\NetCore\BlogApplication\BlogApplication\Areas\Cliente\Views\Home\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n");
#nullable restore
#line 58 "F:\Developments\NetCore\BlogApplication\BlogApplication\Areas\Cliente\Views\Home\Index.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>No Existen articulos..</p>\r\n");
#nullable restore
#line 62 "F:\Developments\NetCore\BlogApplication\BlogApplication\Areas\Cliente\Views\Home\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BlogApplication.Modelos.ViewModels.HomeViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
