#pragma checksum "C:\Users\jdogg\csci540_proj\refactored-parakeet\parakeet\parakeet\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7703fbf4b87527cf4e407fb763bafed394d49f83"
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
#line 1 "C:\Users\jdogg\csci540_proj\refactored-parakeet\parakeet\parakeet\Views\_ViewImports.cshtml"
using parakeet;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\jdogg\csci540_proj\refactored-parakeet\parakeet\parakeet\Views\_ViewImports.cshtml"
using parakeet.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7703fbf4b87527cf4e407fb763bafed394d49f83", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3aa44f461a77fe5f8204720d906feebf1b9352ac", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Design[]>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:240px;height:150px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/image/Parakeet_Logo.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Products", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\jdogg\csci540_proj\refactored-parakeet\parakeet\parakeet\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"container\">\r\n\r\n    <div class=\"jumbotron\">\r\n        <div class=\"text-center\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "7703fbf4b87527cf4e407fb763bafed394d49f834915", async() => {
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
            WriteLiteral(@"
            <h4 style="" font-family:'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif"" class=""text-center"">Amazing Designs | Fantastic Clothing | Awesome Prices</h4>
        </div>
    </div>
    <div class=""container"">
        <div class=""page-header"">

            <h1 style="" font-family:'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif; color:darkorange"" class=""font-weight-bold  text-center"">-Popular Designs-</h1>
        </div>
        <div class=""row"">
");
#nullable restore
#line 21 "C:\Users\jdogg\csci540_proj\refactored-parakeet\parakeet\parakeet\Views\Home\Index.cshtml"
             if (Model == null || Model.Length < 5)
            {
                // there are no designs or less than 5 designs in DB so there is no top 5

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <div class=""col-sm-1""></div>
                <div class=""col-sm-2"">1</div>
                <div class=""col-sm-2"">2</div>
                <div class=""col-sm-2"">3</div>
                <div class=""col-sm-2"">4</div>
                <div class=""col-sm-2"">5</div>
                <div class=""col-sm-1""></div>
");
#nullable restore
#line 31 "C:\Users\jdogg\csci540_proj\refactored-parakeet\parakeet\parakeet\Views\Home\Index.cshtml"
            }
            else
            {
                // there are enough designs in the DB to present 5 designs

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-sm-1\"></div>\r\n                <div class=\"col-sm-2\">\r\n                    <img id=\"profilePicture\" style=\"width:150px;height:160px; object-fit:cover\"");
            BeginWriteAttribute("src", " src=\"", 1531, "\"", 1617, 2);
            WriteAttributeValue("", 1537, "data:image/*;base64,", 1537, 20, true);
#nullable restore
#line 37 "C:\Users\jdogg\csci540_proj\refactored-parakeet\parakeet\parakeet\Views\Home\Index.cshtml"
WriteAttributeValue("", 1557, Convert.ToBase64String(Model[Model.Length-1].DesignArray), 1557, 60, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    \r\n                </div>\r\n                <div class=\"col-sm-2\">\r\n                    <img id=\"profilePicture\" style=\"width:150px;height:160px; object-fit:cover\"");
            BeginWriteAttribute("src", " src=\"", 1802, "\"", 1888, 2);
            WriteAttributeValue("", 1808, "data:image/*;base64,", 1808, 20, true);
#nullable restore
#line 41 "C:\Users\jdogg\csci540_proj\refactored-parakeet\parakeet\parakeet\Views\Home\Index.cshtml"
WriteAttributeValue("", 1828, Convert.ToBase64String(Model[Model.Length-2].DesignArray), 1828, 60, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    \r\n                </div>\r\n                <div class=\"col-sm-2\">\r\n                    <img id=\"profilePicture\" style=\"width:150px;height:160px; object-fit:cover\"");
            BeginWriteAttribute("src", " src=\"", 2073, "\"", 2159, 2);
            WriteAttributeValue("", 2079, "data:image/*;base64,", 2079, 20, true);
#nullable restore
#line 45 "C:\Users\jdogg\csci540_proj\refactored-parakeet\parakeet\parakeet\Views\Home\Index.cshtml"
WriteAttributeValue("", 2099, Convert.ToBase64String(Model[Model.Length-5].DesignArray), 2099, 60, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                   \r\n                </div>\r\n                <div class=\"col-sm-2\">\r\n                    <img id=\"profilePicture\" style=\"width:150px;height:160px; object-fit:cover\"");
            BeginWriteAttribute("src", " src=\"", 2359, "\"", 2445, 2);
            WriteAttributeValue("", 2365, "data:image/*;base64,", 2365, 20, true);
#nullable restore
#line 49 "C:\Users\jdogg\csci540_proj\refactored-parakeet\parakeet\parakeet\Views\Home\Index.cshtml"
WriteAttributeValue("", 2385, Convert.ToBase64String(Model[Model.Length-3].DesignArray), 2385, 60, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    \r\n                </div>\r\n                <div class=\"col-sm-2\">\r\n                    <img id=\"profilePicture\" style=\"width:150px;height:160px; object-fit:cover\"");
            BeginWriteAttribute("src", " src=\"", 2630, "\"", 2716, 2);
            WriteAttributeValue("", 2636, "data:image/*;base64,", 2636, 20, true);
#nullable restore
#line 53 "C:\Users\jdogg\csci540_proj\refactored-parakeet\parakeet\parakeet\Views\Home\Index.cshtml"
WriteAttributeValue("", 2656, Convert.ToBase64String(Model[Model.Length-4].DesignArray), 2656, 60, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    \r\n                </div>\r\n                <div class=\"col-sm-1\"></div>\r\n");
#nullable restore
#line 57 "C:\Users\jdogg\csci540_proj\refactored-parakeet\parakeet\parakeet\Views\Home\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n\r\n\r\n</div>\r\n<div> <p><br /></p></div>\r\n\r\n<div class=\"container\">\r\n\r\n    <div class=\"row\">\r\n        <div class=\"col-sm-2\"></div>\r\n\r\n        <div class=\"col-sm-8 text-center\">\r\n\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7703fbf4b87527cf4e407fb763bafed394d49f8311655", async() => {
                WriteLiteral(" <button style=\"color:darkorange\" class=\"btn btn-outline-info btn-lg\"> Start Your Shirt Order </button> ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

            <h3 style="" font-family:'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif"" class=""align-content-center""><br />Parakeet provides independent artist with a platform to sell their designs</h3>
            <h3 style="" font-family:'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif"" class=""align-content-center""><br />All Designs You love can be added to quality Shirts<br /></h3>


        </div>
        <div class=""col-sm-2""></div>
    </div>


</div>

");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Design[]> Html { get; private set; }
    }
}
#pragma warning restore 1591
