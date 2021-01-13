using GithubJobsEnterpriseProject.Models;
using GithubJobsEnterpriseProject.Services;
using NSubstitute;
using NUnit.Framework;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GithubJobsEnterpriseProject.Tests
{
    class JsonHandlerServiceTests
    {
        public JsonHandlerService jsonHandlerService = new JsonHandlerService();

        [Test]
        public void TestIfUserIsSaved()
        {
            var password = "12345";
            var convertedPassword = new PasswordHandlerService(password).HashUserGivenPassword();
            var user = new User("Dominik456535", "Email@gmail.com", convertedPassword);
            jsonHandlerService.Save(user);
            var users = jsonHandlerService.DeconvertUsersJson();

            Assert.That(users.Any(u => u.Username == "Dominik456535" && u.Password == convertedPassword));
        }

        [Test]
        public void TestIfDeconvertUsersJsonGetsData()
        {
            var user = new User("Dominik456535", "Email@gmail.com", "12345");
            jsonHandlerService.Save(user);
            var users = jsonHandlerService.DeconvertUsersJson();
            var result = users.Count();

            Assert.GreaterOrEqual(result, 1);

        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestIfFileNotFoundExeptionIsThrown()
        {
            var jsonHandlerServiceSubstitude = Substitute.For<IJsonHandlerService>();
            jsonHandlerServiceSubstitude.DeconvertUsersJson().Returns(x => { throw new FileNotFoundException(); });

        }

    }
}
