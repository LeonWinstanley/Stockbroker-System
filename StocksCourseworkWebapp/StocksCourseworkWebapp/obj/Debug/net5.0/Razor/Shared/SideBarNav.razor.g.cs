#pragma checksum "C:\Users\leonw\Desktop\Uni\Service-Centric\ServiceCentric\StocksCourseworkWebapp\StocksCourseworkWebapp\Shared\SideBarNav.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c624d61bee668a659f055d6030815385bcec9446"
// <auto-generated/>
#pragma warning disable 1591
namespace StocksCourseworkWebapp.Shared
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
#nullable restore
#line 1 "C:\Users\leonw\Desktop\Uni\Service-Centric\ServiceCentric\StocksCourseworkWebapp\StocksCourseworkWebapp\Shared\SideBarNav.razor"
using MudBlazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\leonw\Desktop\Uni\Service-Centric\ServiceCentric\StocksCourseworkWebapp\StocksCourseworkWebapp\Shared\SideBarNav.razor"
using Microsoft.AspNetCore.Http.Extensions;

#line default
#line hidden
#nullable disable
    public partial class SideBarNav : LayoutComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<MudBlazor.MudNavMenu>(0);
            __builder.AddAttribute(1, "Style", "margin-top: 0.5rem;");
            __builder.AddAttribute(2, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Authorization.AuthorizeView>(3);
                __builder2.AddAttribute(4, "Authorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder3) => {
                    __builder3.OpenComponent<MudBlazor.MudNavLink>(5);
                    __builder3.AddAttribute(6, "Href", "/");
                    __builder3.AddAttribute(7, "Icon", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 12 "C:\Users\leonw\Desktop\Uni\Service-Centric\ServiceCentric\StocksCourseworkWebapp\StocksCourseworkWebapp\Shared\SideBarNav.razor"
                                        Icons.Material.Home

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(8, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.AddContent(9, "Home");
                    }
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(10, "\r\n            ");
                    __builder3.OpenComponent<MudBlazor.MudNavLink>(11);
                    __builder3.AddAttribute(12, "Href", "/dashboard");
                    __builder3.AddAttribute(13, "Icon", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 13 "C:\Users\leonw\Desktop\Uni\Service-Centric\ServiceCentric\StocksCourseworkWebapp\StocksCourseworkWebapp\Shared\SideBarNav.razor"
                                                 Icons.Material.Dashboard

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(14, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.AddContent(15, "Dashboard");
                    }
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(16, "\r\n            ");
                    __builder3.OpenComponent<MudBlazor.MudNavLink>(17);
                    __builder3.AddAttribute(18, "Href", "/companySearch");
                    __builder3.AddAttribute(19, "Icon", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 14 "C:\Users\leonw\Desktop\Uni\Service-Centric\ServiceCentric\StocksCourseworkWebapp\StocksCourseworkWebapp\Shared\SideBarNav.razor"
                                                     Icons.Material.Search

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(20, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.AddContent(21, "Company Search");
                    }
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(22, "\r\n            ");
                    __builder3.OpenComponent<MudBlazor.MudNavLink>(23);
                    __builder3.AddAttribute(24, "Href", "/account");
                    __builder3.AddAttribute(25, "Icon", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 15 "C:\Users\leonw\Desktop\Uni\Service-Centric\ServiceCentric\StocksCourseworkWebapp\StocksCourseworkWebapp\Shared\SideBarNav.razor"
                                               Icons.Material.AccountCircle

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(26, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.AddContent(27, "Account Settings");
                    }
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(28, "\r\n\r\n            ");
                    __builder3.OpenComponent<MudBlazor.MudNavLink>(29);
                    __builder3.AddAttribute(30, "Href", "/identity/account/logout");
                    __builder3.AddAttribute(31, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.AddContent(32, "Logout");
                    }
                    ));
                    __builder3.CloseComponent();
                }
                ));
                __builder2.AddAttribute(33, "NotAuthorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder3) => {
                    __builder3.OpenComponent<MudBlazor.MudNavLink>(34);
                    __builder3.AddAttribute(35, "Href", "/login");
                    __builder3.AddAttribute(36, "Icon", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 20 "C:\Users\leonw\Desktop\Uni\Service-Centric\ServiceCentric\StocksCourseworkWebapp\StocksCourseworkWebapp\Shared\SideBarNav.razor"
                                             Icons.Material.Login

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(37, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.AddContent(38, "Please Login");
                    }
                    ));
                    __builder3.CloseComponent();
                }
                ));
                __builder2.CloseComponent();
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
    }
}
#pragma warning restore 1591
