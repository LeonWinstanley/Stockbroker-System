// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace StocksCourseworkWebapp.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\leonw\Desktop\Uni\Service-Centric\ServiceCentric\StocksCourseworkWebapp\StocksCourseworkWebapp\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\leonw\Desktop\Uni\Service-Centric\ServiceCentric\StocksCourseworkWebapp\StocksCourseworkWebapp\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\leonw\Desktop\Uni\Service-Centric\ServiceCentric\StocksCourseworkWebapp\StocksCourseworkWebapp\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\leonw\Desktop\Uni\Service-Centric\ServiceCentric\StocksCourseworkWebapp\StocksCourseworkWebapp\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\leonw\Desktop\Uni\Service-Centric\ServiceCentric\StocksCourseworkWebapp\StocksCourseworkWebapp\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\leonw\Desktop\Uni\Service-Centric\ServiceCentric\StocksCourseworkWebapp\StocksCourseworkWebapp\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\leonw\Desktop\Uni\Service-Centric\ServiceCentric\StocksCourseworkWebapp\StocksCourseworkWebapp\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\leonw\Desktop\Uni\Service-Centric\ServiceCentric\StocksCourseworkWebapp\StocksCourseworkWebapp\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\leonw\Desktop\Uni\Service-Centric\ServiceCentric\StocksCourseworkWebapp\StocksCourseworkWebapp\_Imports.razor"
using StocksCourseworkWebapp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\leonw\Desktop\Uni\Service-Centric\ServiceCentric\StocksCourseworkWebapp\StocksCourseworkWebapp\_Imports.razor"
using StocksCourseworkWebapp.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\leonw\Desktop\Uni\Service-Centric\ServiceCentric\StocksCourseworkWebapp\StocksCourseworkWebapp\_Imports.razor"
using MudBlazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\leonw\Desktop\Uni\Service-Centric\ServiceCentric\StocksCourseworkWebapp\StocksCourseworkWebapp\_Imports.razor"
using MudBlazor.Dialog;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\leonw\Desktop\Uni\Service-Centric\ServiceCentric\StocksCourseworkWebapp\StocksCourseworkWebapp\_Imports.razor"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\leonw\Desktop\Uni\Service-Centric\ServiceCentric\StocksCourseworkWebapp\StocksCourseworkWebapp\_Imports.razor"
using StocksCourseworkWebapp.Areas.Identity;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 92 "C:\Users\leonw\Desktop\Uni\Service-Centric\ServiceCentric\StocksCourseworkWebapp\StocksCourseworkWebapp\Pages\Index.razor"
 
    void notAuthClick()
    {
        NavigationManager.NavigateTo("login",true);
    }

    void authClick()
    {
        NavigationManager.NavigateTo("/dashboard");
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
    }
}
#pragma warning restore 1591
