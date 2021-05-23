using Application.BankAccount.CreateBankAccount;
using Application.BankAccount.DeleteAccount;
using Application.BankAccount.Queries;
using BankAppXX.Web.Models;
using Domain.Entity;
using Infrastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAppXX.Web.Controllers
{
    [Authorize(policy: "AccountTransactionPoliciy")]
    public class AccountTransactionController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ISender mediatr;

        public AccountTransactionController(UserManager<ApplicationUser> userManager, ISender mediatr)
        {
            this.userManager = userManager;
            this.mediatr = mediatr;
        }
        [HttpGet]
        public IActionResult NewAccount()
        {
            List<ApplicationUser> users = userManager.Users.ToList();

            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var item in users)
            {
                items.Add(new SelectListItem
                {
                    Value = item.Id,
                    Text = item.UserName
                });
            }

            ViewBag.allusers = items;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewAccount(NewAccountViewModel model)
        {

            CreateBankAccountCommand createBankAccountCommand = new CreateBankAccountCommand
            {
                AccountName = model.AccountName,
                UserId = model.UserId,
                SeedAmount = model.Amount
            };



            int result = await mediatr.Send<int>(createBankAccountCommand);


            return View();
        }


        [HttpGet]
        public async Task<IActionResult> GetAcountTest()
        {

            AccountRequest getaccountquery = new AccountRequest
            {
                AccountId = 1
            };

            BankAccount result = await mediatr.Send<BankAccount>(getaccountquery);

            return View();

        }

        //[HttpGet]
        //public async Task<IActionResult> DeleteAccountTest()
        //{

        //    DeleteAccountCommand deleteAccountCommand = new DeleteAccountCommand
        //    {
        //        AccountId = 1
        //    };

        //    int result = await mediatr.Send<int>(deleteAccountCommand);

        //    return View();

        //}
    }
}
