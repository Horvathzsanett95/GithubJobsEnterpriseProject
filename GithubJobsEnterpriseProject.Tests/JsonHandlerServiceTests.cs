using GithubJobsEnterpriseProject.Models;
using GithubJobsEnterpriseProject.Services;
using NUnit.Framework;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;

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
        public void TestIfFileIsFound()
        {
            IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);
            try
            {
                using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream("users.json", FileMode.Open, isoStore))
                {
                    Assert.Pass();
                }
            }
            catch (FileNotFoundException)
            {
                Assert.Fail();
            }
        }



    }
}
