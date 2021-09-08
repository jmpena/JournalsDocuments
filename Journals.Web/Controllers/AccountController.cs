using Journals.Web.Entities;
using Journals.Web.Infrastructure.Repository.Account;
using Journals.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Journals.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private IAccountRepository accountRepository { get; set; }
        /// <summary>
        ///  inject the repository
        /// </summary>
        /// <param name="_journalsDocumentRepository"></param>
        public AccountController(IAccountRepository _accountRepository, ILogger<AccountController> logger)
        {
            this.accountRepository = _accountRepository;
            _logger = logger;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            try
            {
                var user = accountRepository.Login(model.UserName, model.Password);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View();
                }
                var claims = new List<Claim>
             {
                 new Claim(ClaimTypes.Name, user.Name),
                 new Claim( ClaimTypes.Sid, user.ResearcherId.ToString() )
            };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(
                   CookieAuthenticationDefaults.AuthenticationScheme,
                   new ClaimsPrincipal(claimsIdentity),
                   new AuthenticationProperties
                   {
                       IsPersistent = false
                   });
                return RedirectToAction("JournalsDocuments", "Journals");
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View();
                 
            }
           
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            accountRepository.Register(new Entities.Researcher
            {
                Name = model.Name,
                Password = model.Password,
                UserName = model.UserName
            });
            return RedirectToAction("Login");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
        
    }
}
