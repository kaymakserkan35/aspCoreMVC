#pragma checksum "C:\Users\nyks.35\Desktop\RestApi-looping\uı\Views\Home\Server.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ecc269204c2d2b9e884a52588fc2f1336c600f58"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Server), @"mvc.1.0.view", @"/Views/Home/Server.cshtml")]
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
#line 1 "C:\Users\nyks.35\Desktop\RestApi-looping\uı\Views\_ViewImports.cshtml"
using uı;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\nyks.35\Desktop\RestApi-looping\uı\Views\_ViewImports.cshtml"
using uı.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ecc269204c2d2b9e884a52588fc2f1336c600f58", @"/Views/Home/Server.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c264633fd9e952c7f46bca39f26d11dab14d2117", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Server : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<BookModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\nyks.35\Desktop\RestApi-looping\uı\Views\Home\Server.cshtml"
 foreach (var book in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div>  ");
#nullable restore
#line 5 "C:\Users\nyks.35\Desktop\RestApi-looping\uı\Views\Home\Server.cshtml"
      Write(book.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 5 "C:\Users\nyks.35\Desktop\RestApi-looping\uı\Views\Home\Server.cshtml"
                    Write(book.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </div>\r\n");
#nullable restore
#line 6 "C:\Users\nyks.35\Desktop\RestApi-looping\uı\Views\Home\Server.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<BookModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
