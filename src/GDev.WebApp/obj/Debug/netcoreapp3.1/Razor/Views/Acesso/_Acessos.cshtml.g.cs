#pragma checksum "C:\checkout\GerenciaDev\src\GDev.WebApp\Views\Acesso\_Acessos.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "56f0acf09a7954663e1884dcc65c01c87cf909cf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Acesso__Acessos), @"mvc.1.0.view", @"/Views/Acesso/_Acessos.cshtml")]
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
#line 1 "C:\checkout\GerenciaDev\src\GDev.WebApp\Views\_ViewImports.cshtml"
using GDev.WebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\checkout\GerenciaDev\src\GDev.WebApp\Views\_ViewImports.cshtml"
using GDev.WebApp.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"56f0acf09a7954663e1884dcc65c01c87cf909cf", @"/Views/Acesso/_Acessos.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ee2a4e89a5589c08aaa3bec062a0874b715335b9", @"/Views/_ViewImports.cshtml")]
    public class Views_Acesso__Acessos : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<GDev.WebApp.ViewModels.AcessoViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\checkout\GerenciaDev\src\GDev.WebApp\Views\Acesso\_Acessos.cshtml"
 if (Model != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <table class=\"table table-hover\">\r\n        <thead class=\"thead-dark\">\r\n            <tr>\r\n                <th>\r\n                    ");
#nullable restore
#line 9 "C:\checkout\GerenciaDev\src\GDev.WebApp\Views\Acesso\_Acessos.cshtml"
               Write(Html.DisplayNameFor(model => model.Url));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 12 "C:\checkout\GerenciaDev\src\GDev.WebApp\Views\Acesso\_Acessos.cshtml"
               Write(Html.DisplayNameFor(model => model.Token));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 15 "C:\checkout\GerenciaDev\src\GDev.WebApp\Views\Acesso\_Acessos.cshtml"
               Write(Html.DisplayNameFor(model => model.Modulo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 18 "C:\checkout\GerenciaDev\src\GDev.WebApp\Views\Acesso\_Acessos.cshtml"
               Write(Html.DisplayNameFor(model => model.Cliente));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 21 "C:\checkout\GerenciaDev\src\GDev.WebApp\Views\Acesso\_Acessos.cshtml"
               Write(Html.DisplayNameFor(model => model.DiaCadastro));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 24 "C:\checkout\GerenciaDev\src\GDev.WebApp\Views\Acesso\_Acessos.cshtml"
               Write(Html.DisplayNameFor(model => model.DiaAlteracao));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th></th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 30 "C:\checkout\GerenciaDev\src\GDev.WebApp\Views\Acesso\_Acessos.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 34 "C:\checkout\GerenciaDev\src\GDev.WebApp\Views\Acesso\_Acessos.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Url));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 37 "C:\checkout\GerenciaDev\src\GDev.WebApp\Views\Acesso\_Acessos.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Token));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 40 "C:\checkout\GerenciaDev\src\GDev.WebApp\Views\Acesso\_Acessos.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Modulo.Descricao));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 43 "C:\checkout\GerenciaDev\src\GDev.WebApp\Views\Acesso\_Acessos.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Cliente.RazaoSocial));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 46 "C:\checkout\GerenciaDev\src\GDev.WebApp\Views\Acesso\_Acessos.cshtml"
                   Write(Html.DisplayFor(modelItem => item.DiaCadastro));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 49 "C:\checkout\GerenciaDev\src\GDev.WebApp\Views\Acesso\_Acessos.cshtml"
                   Write(Html.DisplayFor(modelItem => item.DiaAlteracao));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>                \r\n                </tr>\r\n");
#nullable restore
#line 52 "C:\checkout\GerenciaDev\src\GDev.WebApp\Views\Acesso\_Acessos.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
#nullable restore
#line 55 "C:\checkout\GerenciaDev\src\GDev.WebApp\Views\Acesso\_Acessos.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<GDev.WebApp.ViewModels.AcessoViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
