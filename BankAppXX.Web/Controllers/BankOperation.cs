using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAppXX.Web.Controllers
{

    [Authorize(Roles = "Admin")]
    public class BankOperation : Controller
    {
        public IActionResult List()
        {
            return View();
        }
    }
}
