#pragma checksum "C:\Users\Suslick\Desktop\New\TTK\TTK\Views\Admin\UseTariff.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "715f562cdb251de9abd23d1d780acd5c982ea1c0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_UseTariff), @"mvc.1.0.view", @"/Views/Admin/UseTariff.cshtml")]
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
#line 1 "C:\Users\Suslick\Desktop\New\TTK\TTK\Views\_ViewImports.cshtml"
using TTK;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Suslick\Desktop\New\TTK\TTK\Views\_ViewImports.cshtml"
using TTK.Model;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"715f562cdb251de9abd23d1d780acd5c982ea1c0", @"/Views/Admin/UseTariff.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ee3fb6ad9df3b59caf130856a753c8bcebf100b8", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_UseTariff : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TTK.ViewModels.ClientHistory>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Suslick\Desktop\New\TTK\TTK\Views\Admin\UseTariff.cshtml"
  
    Layout = "~/Views/Shared/_LayoutAdmin.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n");
            WriteLiteral(@"
<style>
    .Center {
        text-align: center;
    }
</style>

<div class=""content"">
    <h1 class=""Title"">История</h1>


    <div class=""tabs"">
        <div id=""content-1"">
            <div class=""Table_History"">
                <table>
                    <thead>
                        <tr>
                            <th scope=""col"">Название тарифа</th>
                            <th scope=""col"">Дата</th>
                            <th scope=""col"">Компонент</th>
                            <th scope=""col"">Количество</th>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 35 "C:\Users\Suslick\Desktop\New\TTK\TTK\Views\Admin\UseTariff.cshtml"
                         foreach (var history in Model.historyTraffic)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <th class=\"Center\" scope=\"col\">");
#nullable restore
#line 38 "C:\Users\Suslick\Desktop\New\TTK\TTK\Views\Admin\UseTariff.cshtml"
                                                          Write(Model.tariffName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                <td class=\"Center\" width=\"200px\" scope=\"col\">");
#nullable restore
#line 39 "C:\Users\Suslick\Desktop\New\TTK\TTK\Views\Admin\UseTariff.cshtml"
                                                                        Write(history.Date.ToString("d"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td class=\"Center\" width=\"50px\" scope=\"col\">");
#nullable restore
#line 40 "C:\Users\Suslick\Desktop\New\TTK\TTK\Views\Admin\UseTariff.cshtml"
                                                                       Write(Model.dataTariff.Where(x => x.IdDataTariff == history.DataTariff).First().DataTariffName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td class=\"Center\" width=\"150px\" scope=\"col\">");
#nullable restore
#line 41 "C:\Users\Suslick\Desktop\New\TTK\TTK\Views\Admin\UseTariff.cshtml"
                                                                        Write(history.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            </tr>\r\n");
#nullable restore
#line 43 "C:\Users\Suslick\Desktop\New\TTK\TTK\Views\Admin\UseTariff.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                    </tbody>\r\n                </table>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TTK.ViewModels.ClientHistory> Html { get; private set; }
    }
}
#pragma warning restore 1591
