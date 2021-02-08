using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;
using StocksCourseworkWebapp.Areas.Identity.Pages.Account;
using StocksCourseworkWebapp.Contexts;
using StocksCourseworkWebapp.Models.DatabaseObjects;
using StocksCourseworkWebapp.Models.Payloads;
using Syncfusion.Blazor.Data;
using MudBlazor;

namespace StocksCourseworkWebapp.Services
{
    public class UserService
    {
        private readonly WebAppContext _context;
        private readonly APIService _apiService;
        private readonly ISnackbar _snackBar;
        private readonly NavigationManager _navigatonManager;
        public UserService(WebAppContext context, APIService apiService, ISnackbar snackBar, NavigationManager navigationManager)
        {
            _apiService = apiService;
            _context = context;
            _snackBar = snackBar;
            _navigatonManager = navigationManager;

        }

        public async Task setDefaultCurrency(string currency, string username)
        {
            var userQuery = await _context.AccountDetails.Where(x => x.UserName == username).FirstOrDefaultAsync();
            userQuery.DefaultCurrency = currency;
            await _context.SaveChangesAsync();
            await convertBalance(username);
        }

        public async Task<decimal> fetchBalance(string username)
        {
            await convertBalance(username);
            var userDetails = await _context.AccountDetails.SingleOrDefaultAsync(x => x.UserName == username);

            if (userDetails != null)
            {

                return userDetails.AccountBalance;
            }

            AccountDetails accDetails = new AccountDetails
            {
                UserName = username
            };
            await _context.AccountDetails.AddAsync(accDetails);
            await _context.SaveChangesAsync();

            return userDetails.AccountBalance;
        }

        public async Task<AccountDetails> fetchAccountDetails(string username)
        {
            await convertBalance(username);
            var accountDetails = await _context.AccountDetails.SingleOrDefaultAsync(x => x.UserName == username);
            accountDetails.AccountBalanceAvailable = accountDetails.AccountBalance - await fetchAvailableBalance(username);
            await _context.SaveChangesAsync();
            return accountDetails;
        }

        public async Task<decimal> fetchAvailableBalance(string username)
        {
            await convertBalance(username);
            decimal usedBalance = 0;
            var listOfPurchases = await _context.UserHoldings.Where(x => x.UserName == username).Select(x => new { x.PriceBought, x.Amount, x.PriceSold }).ToListAsync();

            foreach(var element in listOfPurchases)
            {
                usedBalance = (element.PriceSold == 0) ? (element.Amount * element.PriceBought) : usedBalance + 0;
            }

            return usedBalance;
        }

        public async Task convertBalance(string username)
        {
            var account = await _context.AccountDetails.SingleOrDefaultAsync(x => x.UserName == username);
            if(account == null)
            {
                return;
            }
            var balanceConverted = await _apiService.fetchConvertedBalance(account.AccountBalanceAvailable, account.DefaultCurrency);
            account.AccountBalanceConverted = balanceConverted;
            await _context.SaveChangesAsync();
        }

        public async Task<List<UserHoldings>> fetchUserHoldings(string username)
        {
            var userHoldings = await _context.UserHoldings.Where(x => x.UserName == username && x.PriceSold == 0).ToListAsync();
            return userHoldings;
        }

        public async Task<List<UserHoldings>> fetchAllUserHoldings(string username)
        {
            return await _context.UserHoldings.Where(x => x.UserName == username).ToListAsync();

        }

        public async Task purchaseStock(UserHoldings toBuy)
        {
            var account = await fetchAccountDetails(toBuy.UserName);
            var totalAmount = toBuy.PriceBought * toBuy.Amount;
            try
            {
                if (account.AccountBalanceAvailable > totalAmount)
                {
                    await _context.AddAsync(toBuy);
                    await _context.SaveChangesAsync();
                    _snackBar.Add("Your purchase has been completed", Severity.Success);
                    _navigatonManager.NavigateTo(_navigatonManager.Uri, true);
                }
                else
                {
                    _snackBar.Add("You do not have the funds to complete this purchase", Severity.Error);
                }
            }
            catch(Exception e)
            {
                _snackBar.Add("An error has occoured. The purchase has not completed.", Severity.Error);
                Console.WriteLine(e);
            }
        }

        public async Task closePosition(PositionTablePayload toClose, AccountDetails account)
        {
            try
            {
                // need to sell position
                var position = await _context.UserHoldings.FirstOrDefaultAsync(positions => positions.UserName == toClose.UserName && positions.TimeBought == toClose.TimeBought);
                var quote = await _apiService.fetchQuote(toClose.Symbol, account.DefaultCurrency);
                position.PriceSold = quote.CurrentPrice;

                var accountBal = await _context.AccountDetails.FirstOrDefaultAsync(x => x.UserName == account.UserName);
                accountBal.AccountBalance = accountBal.AccountBalance + toClose.ProfitLoss;


                await _context.SaveChangesAsync();
            }
            catch(Exception e)
            {
                _snackBar.Add("An error has occoured. The position has not been closed.", Severity.Error);
                Console.WriteLine(e);
            }
        }

        public async Task deposit(AccountDetails account , decimal amount)
        {
            try
            {
                var accountQuery = await _context.AccountDetails.FirstOrDefaultAsync(x => x.UserName == account.UserName);
                var converted = await _apiService.fetchConvertedToUSD(amount, account.DefaultCurrency);

                accountQuery.AccountBalance = accountQuery.AccountBalance + converted;
                await _context.SaveChangesAsync();
            }
            catch(Exception e)
            {
                _apiService.throwSnackBarError();
                Console.WriteLine(e);
            }
        }
        public async Task withdraw(AccountDetails account, decimal amount)
        {
            try
            {
                var accountQuery = await _context.AccountDetails.FirstOrDefaultAsync(x => x.UserName == account.UserName);
                var converted = await _apiService.fetchConvertedToUSD(amount, account.DefaultCurrency);

                if(accountQuery.AccountBalanceAvailable > converted)
                {
                    accountQuery.AccountBalance = accountQuery.AccountBalance - converted;
                    await _context.SaveChangesAsync();
                    _navigatonManager.NavigateTo(_navigatonManager.Uri, true);
                }
                else
                {
                    _snackBar.Add("You do not have the funds to withdraw", Severity.Warning);
                }
            }
            catch (Exception e)
            {
                _apiService.throwSnackBarError();
                Console.WriteLine(e);
            }

        }
    }
}
