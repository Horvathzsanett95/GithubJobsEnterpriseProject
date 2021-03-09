using GithubJobsEnterpriseProject.Models;
using GithubJobsEnterpriseProject.Services;
using GithubJobsEnterpriseProject.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public UserOperationsController (IUnitOfWork unit,
            IEmailSenderService emailService,
            ILoginService loginService)
        {
            _unit = unit;
            _emailService = emailService;
            _loginService = loginService;
        }
        [HttpPost("/registration")]
        public ActionResult GetCredentials()
        {
            var username = Request.Form["Username"];
            var email = Request.Form["Email"];
            var password = Request.Form["Password"];
            var hashedPassword = PasswordOperations.HashUserGivenPassword(password);
            User user = new User(username, email, hashedPassword);
            _unit.Users.Add(user);
            _unit.Complete();
            _emailService.SendEmail(email);

            return Redirect("/");
        }


        [HttpPost("/login")]
        public ActionResult GetLoginCredentials()
        {

            var username = Request.Form["Username"];
            var password = Request.Form["Password"];
            bool isLogged = _loginService.Login(username, password);
            if(isLogged)
            {
                return Redirect("/");

            }
            return NoContent(); 

        }
    }
}
