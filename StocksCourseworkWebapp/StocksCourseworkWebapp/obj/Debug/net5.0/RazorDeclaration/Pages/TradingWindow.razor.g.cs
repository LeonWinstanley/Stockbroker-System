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
#line 3 "C:\Users\leonw\Desktop\Uni\Service-Centric\ServiceCentric\StocksCourseworkWebapp\StocksCourseworkWebapp\Pages\TradingWindow.razor"
using StocksCourseworkWebapp.Models.Payloads;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\leonw\Desktop\Uni\Service-Centric\ServiceCentric\StocksCourseworkWebapp\StocksCourseworkWebapp\Pages\TradingWindow.razor"
using StocksCourseworkWebapp.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\leonw\Desktop\Uni\Service-Centric\ServiceCentric\StocksCourseworkWebapp\StocksCourseworkWebapp\Pages\TradingWindow.razor"
using Syncfusion.Blazor.Charts;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\leonw\Desktop\Uni\Service-Centric\ServiceCentric\StocksCourseworkWebapp\StocksCourseworkWebapp\Pages\TradingWindow.razor"
using StocksCourseworkWebapp.Models.DatabaseObjects;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/trading-window/{symbol}")]
    public partial class TradingWindow : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 164 "C:\Users\leonw\Desktop\Uni\Service-Centric\ServiceCentric\StocksCourseworkWebapp\StocksCourseworkWebapp\Pages\TradingWindow.razor"
      
    [Parameter]
    public string symbol { get; set; }
    public int stockQuantity = 1;
    public StockQuotePayload currentPrice = new StockQuotePayload();
    public AccountDetails account = new AccountDetails();

    public IEnumerable<candleSticksPayload> CandleData = new List<candleSticksPayload>();
    public IEnumerable<AutoCompletePayload> autoCompleteStrings = new List<AutoCompletePayload>();

    public List<UserHoldings> accountHoldings = new List<UserHoldings>();
    public List<StockQuotePayload> currentPositionPrices = new List<StockQuotePayload>();
    public List<PositionTablePayload> tablePayload = new List<PositionTablePayload>();

    protected override async Task OnInitializedAsync()
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;

        if (user.Identity.IsAuthenticated)
        {
            account = await UserService.fetchAccountDetails(user.Identity.Name);
            CandleData = await ApiService.fetchCandles(symbol, "15", 60, account.DefaultCurrency); //auto render
            accountHoldings = await UserService.fetchUserHoldings(account.UserName);
            currentPrice = await ApiService.fetchQuote(symbol, account.DefaultCurrency);
            await fetchQuotes();
            StateHasChanged();
        }
        else
        {
            NavigationManager.NavigateTo("/", true);
        }
    }

    private async Task fetchQuotes()
    {
        foreach (var element in accountHoldings)
        {
            var tempQuote = await ApiService.fetchQuote(element.Symbol, account.DefaultCurrency);

            PositionTablePayload tempTablePayload = new PositionTablePayload
            {
                UserName = element.UserName,
                Amount = element.Amount,
                CurrentPrice = Math.Round(tempQuote.CurrentPrice, 2),
                Symbol = element.Symbol,
                PriceBought = Math.Round(element.PriceBought, 2),
                Type = element.Type,
                TimeBought = element.TimeBought,
                ProfitLoss = (element.Type == "BUY") ? (tempQuote.CurrentPrice - element.PriceBought) * element.Amount : (element.PriceBought - tempQuote.CurrentPrice) * element.Amount
            };
            tablePayload.Add(tempTablePayload);
        }
    }

    private async Task UpdateCandleChart(string value)
    {
        try
        {
            var fetchSymbol = autoCompleteStrings.Where(symbol => symbol.CompanyName == value).Select(symbol => symbol.Symbol);
            CandleData = await ApiService.fetchCandles(fetchSymbol.FirstOrDefault(), "15", 7, account.DefaultCurrency);
            symbol = fetchSymbol.FirstOrDefault();
            currentPrice = await ApiService.fetchQuote(symbol, account.DefaultCurrency);
            StateHasChanged();
        }
        catch (Exception e)
        {
            ApiService.throwSnackBarError();
            Console.WriteLine(e);
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
            throw;
        }
    }

    private async Task buyStock()
    {
        UserHoldings holdings = new UserHoldings();

        holdings.Amount = stockQuantity;
        holdings.PriceBought = currentPrice.CurrentPrice;
        holdings.TimeBought = DateTimeOffset.Now;
        holdings.Symbol = symbol;
        holdings.UserName = account.UserName;
        holdings.Type = "BUY";

        await UserService.purchaseStock(holdings);
    }

    private async Task shortStock()
    {
        UserHoldings holdings = new UserHoldings();

        holdings.Amount = stockQuantity;
        holdings.PriceBought = currentPrice.CurrentPrice;
        holdings.TimeBought = DateTimeOffset.Now;
        holdings.Symbol = symbol;
        holdings.UserName = account.UserName;
        holdings.Type = "SHORT";

        await UserService.purchaseStock(holdings);
    }

    private async Task closePosition(PositionTablePayload holdings)
    {
        await UserService.closePosition(holdings, account);
        NavigationManager.NavigateTo(NavigationManager.Uri, true);
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private UserService UserService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private APIService ApiService { get; set; }
    }
}
#pragma warning restore 1591
