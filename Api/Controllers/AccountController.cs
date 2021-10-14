using Api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    public class AccountController : Controller
    {
        [HttpPost]
        public IActionResult Register(UserRegisterViewModel u)
        {
            return View();
        }

        public IActionResult Register()
        {
            var viewModel = new UserRegisterViewModel();

            return View(viewModel);
        }
    }
}
