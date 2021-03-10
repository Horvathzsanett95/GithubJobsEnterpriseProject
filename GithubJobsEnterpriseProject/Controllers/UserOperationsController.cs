using GithubJobsEnterpriseProject.Models;
using GithubJobsEnterpriseProject.Services;
using GithubJobsEnterpriseProject.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GithubJobsEnterpriseProject.Controllers
{
    [Route("users")]
    [ApiController]
    public class UserOperationsController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        private readonly IEmailSenderService _emailService;
        private readonly ILoginService _loginService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public UserOperationsController (IUnitOfWork unit,
            IEmailSenderService emailService,
            ILoginService loginService,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _unit = unit;
            _emailService = emailService;
            _loginService = loginService;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        [HttpPost("/registration")]
        public async Task<ActionResult> RegisterNewUser()
        {
            var username = Request.Form["Username"];
            var email = Request.Form["Email"];
            var password = Request.Form["Password"];
            var hashedPassword = PasswordOperations.HashUserGivenPassword(password);
            var user = new IdentityUser { UserName = username, Email = email };
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                _emailService.SendEmail(email);
                await _signInManager.SignInAsync(user, isPersistent: true);
                return Redirect("/");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("Error: ", error.Description);
            }
            return NoContent();
        }


        [HttpPost("/login")]
        public async Task<ActionResult> GetLoginCredentials()
        {
            var username = Request.Form["Username"];
            var password = Request.Form["Password"];
            var result = await _signInManager.PasswordSignInAsync(username, password, isPersistent: true, false) ;
            if(result.Succeeded)
            {
                var user = new IdentityUser { UserName = username};
                await _signInManager.SignInAsync(user, isPersistent: true);
                return Redirect("/");
            }
                
            
            return NoContent(); 
        }

        [HttpGet("/getCookieData")]
        public string GetCookieData()
        {
            var user = HttpContext.User;
            Console.WriteLine(user.Identity.Name);
            return user.Identity.Name;
        }


        [HttpGet("/logout")]
        public RedirectResult Logout()
        {
            _signInManager.SignOutAsync();
            return Redirect("/");
        }
    }
}
