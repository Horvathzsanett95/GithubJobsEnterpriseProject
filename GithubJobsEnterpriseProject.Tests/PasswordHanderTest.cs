using GithubJobsEnterpriseProject.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GithubJobsEnterpriseProject.Tests
{
    class PasswordHanderTest
    {
        [Test]
        public void TestIsPasswordIsConverted()
        {
            PasswordHandlerService passwordHanderService = new PasswordHandlerService("Password");
            var result = passwordHanderService.HashUserGivenPassword();

            Assert.AreNotEqual("Password", result);
        }
    }
}
