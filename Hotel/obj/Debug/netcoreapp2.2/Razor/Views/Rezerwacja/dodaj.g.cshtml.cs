#pragma checksum "D:\165460\KSR\Hotel\Hotel\Views\Rezerwacja\dodaj.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1a66ec22d6beb9e063f2766acb559fb37fea6d2e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Rezerwacja_dodaj), @"mvc.1.0.view", @"/Views/Rezerwacja/dodaj.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Rezerwacja/dodaj.cshtml", typeof(AspNetCore.Views_Rezerwacja_dodaj))]
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
#line 1 "D:\165460\KSR\Hotel\Hotel\Views\_ViewImports.cshtml"
using Hotel;

#line default
#line hidden
#line 2 "D:\165460\KSR\Hotel\Hotel\Views\_ViewImports.cshtml"
using Hotel.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1a66ec22d6beb9e063f2766acb559fb37fea6d2e", @"/Views/Rezerwacja/dodaj.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"00630510a69c62db4e186dce360504dace6c5285", @"/Views/_ViewImports.cshtml")]
    public class Views_Rezerwacja_dodaj : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "D:\165460\KSR\Hotel\Hotel\Views\Rezerwacja\dodaj.cshtml"
  
    ViewData["Title"] = "dodaj";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(88, 95, true);
            WriteLiteral("\r\n<h1>Dodawanie nowej rezerwacji</h1>\r\n<i>Podaj dane potrzebne do wprowadzenia rezerwacji</i>\r\n");
            EndContext();
#line 8 "D:\165460\KSR\Hotel\Hotel\Views\Rezerwacja\dodaj.cshtml"
 using (Html.BeginForm())
{

#line default
#line hidden
            BeginContext(213, 12, true);
            WriteLiteral("    <br />\r\n");
            EndContext();
            BeginContext(230, 26, false);
#line 11 "D:\165460\KSR\Hotel\Hotel\Views\Rezerwacja\dodaj.cshtml"
Write(Html.Label("Numer pokoju"));

#line default
#line hidden
            EndContext();
            BeginContext(256, 8, true);
            WriteLiteral("<br />\r\n");
            EndContext();
            BeginContext(269, 27, false);
#line 12 "D:\165460\KSR\Hotel\Hotel\Views\Rezerwacja\dodaj.cshtml"
Write(Html.TextBox("numerPokoju"));

#line default
#line hidden
            EndContext();
            BeginContext(298, 12, true);
            WriteLiteral("    <br />\r\n");
            EndContext();
            BeginContext(315, 54, false);
#line 14 "D:\165460\KSR\Hotel\Hotel\Views\Rezerwacja\dodaj.cshtml"
Write(Html.Label("Data rozpoczęcia rezerwacji (rrrr-mm-dd)"));

#line default
#line hidden
            EndContext();
            BeginContext(376, 22, false);
#line 15 "D:\165460\KSR\Hotel\Hotel\Views\Rezerwacja\dodaj.cshtml"
Write(Html.TextBox("dataOd"));

#line default
#line hidden
            EndContext();
            BeginContext(400, 12, true);
            WriteLiteral("    <br />\r\n");
            EndContext();
            BeginContext(417, 54, false);
#line 17 "D:\165460\KSR\Hotel\Hotel\Views\Rezerwacja\dodaj.cshtml"
Write(Html.Label("Data zakończenia rezerwacji (rrrr-mm-dd)"));

#line default
#line hidden
            EndContext();
            BeginContext(478, 22, false);
#line 18 "D:\165460\KSR\Hotel\Hotel\Views\Rezerwacja\dodaj.cshtml"
Write(Html.TextBox("dataDo"));

#line default
#line hidden
            EndContext();
            BeginContext(502, 54, true);
            WriteLiteral("    <br />\r\n    <button type=\"submit\">Dodaj</button>\r\n");
            EndContext();
#line 21 "D:\165460\KSR\Hotel\Hotel\Views\Rezerwacja\dodaj.cshtml"
}

#line default
#line hidden
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
