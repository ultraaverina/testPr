using Api.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Authorize]
    public class CabinetController : Controller
    {
        //private UserManager<IdentityUser> _userManager;
        //private readonly TestTaskContext _context;
        //public CabinetController(TestTaskContext context,UserManager<IdentityUser> manager)
        //{
        //    _context = context;
        //    _userManager = manager;
        //}

      
        public IActionResult Index()
        {
            

          return View();
         
        }
        //public async void GetUserInfo()
        //{
        //    var user = await _userManager.GetUserAsync(User);
        //    var email = user.Email;
        //    var phone = user.PhoneNumber;
        //    var FIO = user.NormalizedUserName;
        

        //}



        public IActionResult Exit(){ 
            
            return RedirectToAction("Login","Account");
        }
    }
}
