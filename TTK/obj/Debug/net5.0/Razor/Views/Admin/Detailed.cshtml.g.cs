#pragma checksum "C:\Users\Suslick\Desktop\New\TTK\TTK\Views\Admin\Detailed.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "89858e907153afb9668b5bdb59fdd7188a14aa30"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Detailed), @"mvc.1.0.view", @"/Views/Admin/Detailed.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"89858e907153afb9668b5bdb59fdd7188a14aa30", @"/Views/Admin/Detailed.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ee3fb6ad9df3b59caf130856a753c8bcebf100b8", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Detailed : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TTK.ViewModels.Admin.DetailController>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/ButtonStyle.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/Detailed/Client.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 1 "C:\Users\Suslick\Desktop\New\TTK\TTK\Views\Admin\Detailed.cshtml"
  
    Layout = "~/Views/Shared/_LayoutAdmin.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral(@"<style>
    .content {
        width: calc(100% - 78px);
        overflow: auto;
    }

    .component {
        width: calc(100%/3);
    }

    .Components_tarif {
        display: flex;
        flex-wrap: wrap;
        color:white;
    }
    g{
        color:white;
    }
    
</style>

");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "89858e907153afb9668b5bdb59fdd7188a14aa304686", async() => {
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
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "89858e907153afb9668b5bdb59fdd7188a14aa305804", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<div class=\"content\">\r\n    <!-- Title -->\r\n    <div class=\"Title_Pa\">\r\n        <h1>");
#nullable restore
#line 33 "C:\Users\Suslick\Desktop\New\TTK\TTK\Views\Admin\Detailed.cshtml"
       Write(Model.tariff.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n    </div>\r\n    <div id=\"Tarif_diagaramma\" class=\"diagramma\" style=\"width: 1000px; height: 500px;\"></div>\r\n");
            WriteLiteral(@"    <section class=""Section_Client"">
        <div class=""Title_Section"">
            <h2>???????????????????????? ??????????????</h2>
        </div>
        <div class=""Clents"">
            <div class=""Table_withClient"">

                <table class=""table_client"">
                    <thead>
                        <tr>
                            <th scope=""col"">??????</th>
                            <th scope=""col"">??????????</th>
                            <th scope=""col"">??????????????????</th>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 71 "C:\Users\Suslick\Desktop\New\TTK\TTK\Views\Admin\Detailed.cshtml"
                         for (int i = 0; i < Model.users.Count; i++)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td scope=\"row\">");
#nullable restore
#line 74 "C:\Users\Suslick\Desktop\New\TTK\TTK\Views\Admin\Detailed.cshtml"
                                           Write(Model.client[i].Fullname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 75 "C:\Users\Suslick\Desktop\New\TTK\TTK\Views\Admin\Detailed.cshtml"
                               Write(Model.tariff.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>\r\n                                    <div class=\"Button_table\">\r\n                                        <button class=\"btn_table btn1 service_button\" type=\"button\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2412, "\"", 2561, 5);
            WriteAttributeValue("", 2422, "window.location.href", 2422, 20, true);
            WriteAttributeValue(" ", 2442, "=", 2443, 2, true);
            WriteAttributeValue(" ", 2444, "\'", 2445, 2, true);
#nullable restore
#line 78 "C:\Users\Suslick\Desktop\New\TTK\TTK\Views\Admin\Detailed.cshtml"
WriteAttributeValue("", 2446, Url.Action("ClientInfo", "Admin", new { id = Model.client[i].ClientId} ), 2446, 114, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2560, "\'", 2560, 1, true);
            EndWriteAttribute();
            WriteLiteral(">??????????????????</button>\r\n                                    </div>\r\n                                </td>\r\n\r\n                            </tr>\r\n");
#nullable restore
#line 83 "C:\Users\Suslick\Desktop\New\TTK\TTK\Views\Admin\Detailed.cshtml"

                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </tbody>\r\n                </table>\r\n            </div>\r\n        </div>\r\n    </section>\r\n</div>\r\n\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"

    <script type=""text/javascript"" src=""https://www.gstatic.com/charts/loader.js""></script>
    <script type=""text/javascript"">

        google.charts.load('current', { 'packages': ['corechart'] });
        google.charts.setOnLoadCallback(LoadData);

        function LoadData() {
            $(function () {
                $.ajax({

                    type: ""GET"",
                    url: '/Admin/GetDrawTotalMouth/");
#nullable restore
#line 108 "C:\Users\Suslick\Desktop\New\TTK\TTK\Views\Admin\Detailed.cshtml"
                                              Write(Model.tariff.TariffId);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"',
                    /*dataType: ""json"",*/
                    success: function (chartsdata) {
                        var Data = chartsdata.jsonList;

                        var data = new google.visualization.DataTable();
                        data.addColumn('string', 'Date');
                        data.addColumn('number', '???????????????????? ????????????????????????');

                        for (var i = 0; i < Data.length; i++) {

                            data.addRow([Data[i].date, Data[i].count]);
                        }

                        var chart = new google.visualization.ColumnChart(document.getElementById('Tarif_diagaramma'));

                        chart.draw(data, {
                            legend: {
                                textStyle: {
                                    color: 'white'
                                }
                            },
                            title: '?????????????????? ????????????????????????',
                            titleTextStyle: {
   ");
                WriteLiteral(@"                             color: 'white',
                                fontSize: 30
                            },
                            hAxis: {
                                title: '??????????',
                                titleTextStyle: {
                                    color: 'white',
                                },
                                gridlines: {
                                    color: 'white'
                                },
                                textStyle: {
                                    color: 'white'
                                }
                            },
                           
                            vAxis: {
                                title: '??????.',
                                titleTextStyle: {
                                    color: 'white',
                                },
                                gridlines: {
                                    color: 'white'
                     ");
                WriteLiteral(@"           },
                                textStyle: {
                                    color:'white'
                                }

                            },
                            
                            fontsize: 20,
                            backgroundColor: 'transparent',
                            colors: ['red', '#800000', '#00FF00', '#800080', '#FFA500']


                        });

                    },
                    error: function () {
                        alert('Error loading data')
                    }
                })
            });


        }

    </script>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TTK.ViewModels.Admin.DetailController> Html { get; private set; }
    }
}
#pragma warning restore 1591
