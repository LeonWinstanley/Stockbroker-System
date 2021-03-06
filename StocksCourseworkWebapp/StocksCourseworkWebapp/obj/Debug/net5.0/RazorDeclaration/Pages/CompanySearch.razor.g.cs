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
#nullable restore
#line 2 "C:\Users\leonw\Desktop\Uni\Service-Centric\ServiceCentric\StocksCourseworkWebapp\StocksCourseworkWebapp\Pages\CompanySearch.razor"
using StocksCourseworkWebapp.Models.Payloads;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\leonw\Desktop\Uni\Service-Centric\ServiceCentric\StocksCourseworkWebapp\StocksCourseworkWebapp\Pages\CompanySearch.razor"
using StocksCourseworkWebapp.Services;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/CompanySearch")]
    public partial class CompanySearch : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 216 "C:\Users\leonw\Desktop\Uni\Service-Centric\ServiceCentric\StocksCourseworkWebapp\StocksCourseworkWebapp\Pages\CompanySearch.razor"
       

    public IEnumerable<candleSticksPayload> CandleData = new List<candleSticksPayload>();
    public IEnumerable<AutoCompletePayload> autoCompleteStrings = new List<AutoCompletePayload>();
    public CompanyProfilePayload CompanyProfile = new CompanyProfilePayload();
    public List<CompanyNewsPayload> CompanyNews = new List<CompanyNewsPayload>();
    public AdvancedSearch advancedSearch = new AdvancedSearch();
    public List<CompanyProfilePayload> advancedSearchTableData = new List<CompanyProfilePayload>();
    public bool showCompanyProfile = false;
    public bool showAdvancedSearch = false;
    public bool showTable = false;
    public int newsViewCount;
    public int flexSizeSwitcher;
    private CompanyProfilePayload _value = new CompanyProfilePayload();
    public CompanyProfilePayload TableItemSelected { get { return _value; } set { _value = value;  OnSelect(); } }

    protected override async Task OnInitializedAsync()
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;

        if (user.Identity.IsAuthenticated)
        {

        }
        else
        {
            NavigationManager.NavigateTo("/", true);
        }
    }

    private async Task OnSelect()
    {
        try
        {
            CompanyProfile = await ApiService.fetchCompanyProfile(TableItemSelected.Symbol);
            CompanyNews = await ApiService.fetchCompanyNews(TableItemSelected.Symbol);
            showCompanyProfile = true;
            showTable = false;
            showAdvancedSearch = false;
            advancedSearchTableData = new List<CompanyProfilePayload>();
            newsViewCount = 1;
            flexSizeSwitcher = 6;

            if (CompanyProfile.CompanyName == null)
            {
                Snackbar.Add("Sorry we could not find that company. Please try another.", Severity.Warning);
            }

            await JS.InvokeVoidAsync("clickButton");

        }
        catch (Exception e)
        {
            ApiService.throwSnackBarError();
            Console.WriteLine(e);
        }
    }

    private async Task OnSearch(string value)
    {
        try
        {
            var stringinput = autoCompleteStrings.Where(name => name.CompanyName == value).Select(name => name.Symbol).FirstOrDefault();

            if (stringinput != null)
            {

                CompanyProfile = await ApiService.fetchCompanyProfile(stringinput);
                CompanyNews = await ApiService.fetchCompanyNews(stringinput);
                showCompanyProfile = true;
                showTable = false;
                showAdvancedSearch = false;
                advancedSearchTableData = new List<CompanyProfilePayload>();
                newsViewCount = 1;
                flexSizeSwitcher = 6;

                if (CompanyProfile.CompanyName == null)
                {
                    Snackbar.Add("Sorry we could not find that company. Please try another.", Severity.Warning);
                }
            }
            else
            {
                throw new Exception();
            }
        }
        catch (Exception e)
        {
            ApiService.throwSnackBarError();
            Console.WriteLine(e);
        }
    }

    private void displayNextNews()
    {
        try
        {
            if (CompanyNews.Count > newsViewCount)
            {
                newsViewCount++;
            }
            else
            {
                Snackbar.Add("No more news story's exist. Sorry for the inconvenience", Severity.Info);
            }
        }
        catch (Exception e)
        {
            ApiService.throwSnackBarError();
            Console.WriteLine(e);
        }
    }

    private void displayPreviousNews()
    {
        try
        {
            if (newsViewCount != 1)
            {
                newsViewCount--;
            }
            else
            {
                Snackbar.Add("This is the first news story.", Severity.Info);
            }
        }
        catch (Exception e)
        {
            ApiService.throwSnackBarError();
            Console.WriteLine(e);
        }
    }

    private async Task runAdvancedSearch()
    {

        try
        {
            advancedSearchTableData = await ApiService.fetchAdvancedAutoSearch(advancedSearch);
            if(advancedSearchTableData.Count == 0)
            {
                Snackbar.Add("We were unable to find any results. Please try the normal search, or change your query.", Severity.Warning);
            }
            else
            {
                showTable = true;
            }

            StateHasChanged();
        }
        catch
        {
            ApiService.throwSnackBarError();
        }
    }

    private async Task<IEnumerable<string>> StockSearch(string value)
    {
        try
        {
            if (string.IsNullOrEmpty(value))
            {
                return new string[0];
            }
            autoCompleteStrings = await ApiService.autoCompleteSymbolSearch(value);
            return autoCompleteStrings.Select(symbol => symbol.CompanyName);
        }
        catch (Exception e)
        {
            ApiService.throwSnackBarError();
            Console.WriteLine(e);
            return new string[0];
        }

    }

    private void renderChart()
    {
        var url = string.Format($"/trading-window/{CompanyProfile.Symbol}");
        NavigationManager.NavigateTo(url, true);
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JS { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ISnackbar Snackbar { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private APIService ApiService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
    }
}
#pragma warning restore 1591
