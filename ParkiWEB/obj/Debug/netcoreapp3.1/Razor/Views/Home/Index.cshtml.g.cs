#pragma checksum "C:\Users\Burak\Documents\GitHub\natParkiAPIwithNetMVC\ParkiWEB\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "307bff0a7232da85b40c370da05541d0a10a2866"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\Burak\Documents\GitHub\natParkiAPIwithNetMVC\ParkiWEB\Views\_ViewImports.cshtml"
using ParkiWEB;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Burak\Documents\GitHub\natParkiAPIwithNetMVC\ParkiWEB\Views\_ViewImports.cshtml"
using ParkiWEB.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"307bff0a7232da85b40c370da05541d0a10a2866", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9984214517c9cc25d4da9a0f13ee7b8a4f8e87e2", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ParkiWEB.Models.IndexViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Burak\Documents\GitHub\natParkiAPIwithNetMVC\ParkiWEB\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h1 class=\"display-4\">Welcome to natParkiAPI</h1>\r\n</div>\r\n\r\n<div class=\"container\">\r\n    <div class=\"row pb-4 backgroundWhite\">\r\n");
#nullable restore
#line 12 "C:\Users\Burak\Documents\GitHub\natParkiAPIwithNetMVC\ParkiWEB\Views\Home\Index.cshtml"
         foreach (var nationalPark in Model.NationalParkList)
        {


#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <div class=""container backgroundWhite pb-4"">
                <div class=""card border rounded "">
                    <div class=""card-header bg-dark text-light ml-0 row container"">
                        <div class=""col-12 col-md-6"">
                            <h1 class=""text-warning"">");
#nullable restore
#line 19 "C:\Users\Burak\Documents\GitHub\natParkiAPIwithNetMVC\ParkiWEB\Views\Home\Index.cshtml"
                                                Write(nationalPark.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n                        </div>\r\n                        <div class=\"col-12 col-md-6 text-md-right\">\r\n                            <h1 class=\"text-warning\">Location : ");
#nullable restore
#line 22 "C:\Users\Burak\Documents\GitHub\natParkiAPIwithNetMVC\ParkiWEB\Views\Home\Index.cshtml"
                                                           Write(nationalPark.Location);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h1>
                        </div>
                    </div>
                    <div class=""card-body"">
                        <div class=""container rounded p-2"">
                            <div class=""row"">
                                <div class=""col-12 col-lg-8"">
                                    <div class=""row"">
                                        <div class=""col-12"">
                                            <h3 class=""text-dark"">Listing Date: ");
#nullable restore
#line 31 "C:\Users\Burak\Documents\GitHub\natParkiAPIwithNetMVC\ParkiWEB\Views\Home\Index.cshtml"
                                                                           Write(nationalPark.ListingDate.Date.ToString("dd.MM.yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                                        </div>\r\n                                        <div class=\"col-12\">\r\n");
#nullable restore
#line 34 "C:\Users\Burak\Documents\GitHub\natParkiAPIwithNetMVC\ParkiWEB\Views\Home\Index.cshtml"
                                             if (Model.TrailList.Where(U => U.NationalParkId == nationalPark.Id).Count() > 0)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                                <table class=""table table-hover table-curved table-responsive"">
                                                    <thead class=""thead-dark"">
                                                        <tr>
                                                            <th scope=""row"">Trail</th>
                                                            <th scope=""row"">Distance</th>
                                                            <th scope=""row"">Elevation Gain</th>
                                                            <th scope=""row"">Difficulty</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
");
#nullable restore
#line 46 "C:\Users\Burak\Documents\GitHub\natParkiAPIwithNetMVC\ParkiWEB\Views\Home\Index.cshtml"
                                                         foreach (var trails in Model.TrailList.Where(U => U.NationalParkId == nationalPark.Id))
                                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                            <tr>\r\n                                                                <td>");
#nullable restore
#line 49 "C:\Users\Burak\Documents\GitHub\natParkiAPIwithNetMVC\ParkiWEB\Views\Home\Index.cshtml"
                                                               Write(trails.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                                <td>");
#nullable restore
#line 50 "C:\Users\Burak\Documents\GitHub\natParkiAPIwithNetMVC\ParkiWEB\Views\Home\Index.cshtml"
                                                               Write(trails.Distance);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Kilometer</td>\r\n                                                                <td>");
#nullable restore
#line 51 "C:\Users\Burak\Documents\GitHub\natParkiAPIwithNetMVC\ParkiWEB\Views\Home\Index.cshtml"
                                                               Write(trails.Elevation);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Meter</td>\r\n                                                                <td>");
#nullable restore
#line 52 "C:\Users\Burak\Documents\GitHub\natParkiAPIwithNetMVC\ParkiWEB\Views\Home\Index.cshtml"
                                                               Write(trails.Difficulty);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                            </tr>\r\n");
#nullable restore
#line 54 "C:\Users\Burak\Documents\GitHub\natParkiAPIwithNetMVC\ParkiWEB\Views\Home\Index.cshtml"
                                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    </tbody>\r\n                                                </table>\r\n");
#nullable restore
#line 57 "C:\Users\Burak\Documents\GitHub\natParkiAPIwithNetMVC\ParkiWEB\Views\Home\Index.cshtml"
                                            }
                                            else
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <p>No trails found...</p>\r\n");
#nullable restore
#line 61 "C:\Users\Burak\Documents\GitHub\natParkiAPIwithNetMVC\ParkiWEB\Views\Home\Index.cshtml"
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        </div>\r\n                                    </div>\r\n                                </div>\r\n                                <div class=\"col-12 col-lg-4 text-center rounded\">\r\n");
#nullable restore
#line 66 "C:\Users\Burak\Documents\GitHub\natParkiAPIwithNetMVC\ParkiWEB\Views\Home\Index.cshtml"
                                       
                                        var base64 = Convert.ToBase64String(nationalPark.Image);
                                        var finalString = string.Format("data:image/jpg;base64,{0}", base64);
                                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <img");
            BeginWriteAttribute("src", " src=\"", 4178, "\"", 4196, 1);
#nullable restore
#line 70 "C:\Users\Burak\Documents\GitHub\natParkiAPIwithNetMVC\ParkiWEB\Views\Home\Index.cshtml"
WriteAttributeValue("", 4184, finalString, 4184, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"card-img-top p-2 rounded\" width=\"100%\" />\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 77 "C:\Users\Burak\Documents\GitHub\natParkiAPIwithNetMVC\ParkiWEB\Views\Home\Index.cshtml"

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ParkiWEB.Models.IndexViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
