using Api.Data;
using Api.Models;
using Logic.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Api.Controllers
{
    public class AccountController : Controller
    {
        private readonly TestTaskContext _context;
        public AccountController(TestTaskContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel u)
        {
            if (!ModelState.IsValid)
            {
                return View(u);
            }

            var existUser = _context.Users.Any(x => x.Phone == u.Phone && x.Password == u.Password);

            if(!existUser)
            {
                ModelState.AddModelError("", "Неверный логин или пароль.");
                return View(u);
            }

            await Authenticate(u.Phone);

            return RedirectToAction("Index", "Cabinet");
        }

        public IActionResult Login()
        {
            var viewModel = new UserLoginViewModel();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Register(UserRegisterViewModel u)
        {
            if(!ModelState.IsValid)
            {
                return View(u);
            }

            var existUser = _context.Users.Any(x => x.Email == u.Email || x.Phone == u.Phone);
            
            if(existUser)
            {
                ModelState.AddModelError("", "Пользователь с таким именем существует.");
                return View(u);
            }

            var user = new User
            {
                Phone = u.Phone,
                FIO=u.FIO,
                Email=u.Email,
                Password=u.Password
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return View("RegisterSuccess", u);
        }

        public IActionResult Register()
        {
            var viewModel = new UserRegisterViewModel();

            return View(viewModel);
        }

        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };

            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
           
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
