using GithubJobsEnterpriseProject.Models;
using GithubJobsEnterpriseProject.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GithubJobsEnterpriseProject.Tests
{
    class LoginServiceTest
    {
     
        [Test]
        public void TestIfWeGetLoggedIn()
        {
            var jsonHanderService = new JsonHandlerService();
            var password = "password12345";
            var passwordHanderService = new PasswordHandlerService(password);
            var convertedPassword = passwordHanderService.HashUserGivenPassword();

            var user = new User("username12", "email", convertedPassword);
            jsonHanderService.Save(user);

            var allUsers = jsonHanderService.DeconvertUsersJson();

            var loginService = new LoginService("username12","password12345",allUsers);
            Assert.IsTrue(loginService.Login());
           
        }
    }
}
