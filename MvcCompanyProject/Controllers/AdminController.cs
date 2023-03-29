using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MvcCompanyProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MvcCompanyProject.Controllers
{
    public class AdminController : Controller
    {
        Context c = new Context();
        [HttpGet]
        public IActionResult GirisYap()
        {
            return View();
        }

        public async Task<IActionResult> GirisYap(Admin a)
        {
            var values = c.Admins.FirstOrDefault(x => x.UserName == a.UserName && x.Password == a.Password);

            if (values != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, a.UserName)
                };

                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);

                return RedirectToAction("Index", "Employee");
            }

            return View();
        }

        public async Task<IActionResult> CikisYap()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
    }
}
