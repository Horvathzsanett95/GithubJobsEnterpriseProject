﻿using GithubJobsEnterpriseProject.Services;
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
        public void EncryptPasswordToHashCodeShouldReturnSafePasswordTest()
        {
            PasswordHandlerService service = new PasswordHandlerService();
            string password = "123";
            string hashedPwd = service.HashUserGivenPassword(password);
            Assert.AreNotEqual(hashedPwd, password);
            Assert.IsTrue(hashedPwd.Length > password.Length);
        }

        [Test]
        public void DecríptPasswordFromHashReturnsTrueTest()
        {
            PasswordHandlerService service = new PasswordHandlerService();
            string password = "123";
            string hashedPwd = service.HashUserGivenPassword(password);
            bool isMatching = service.PasswordValidator(hashedPwd, password);
            Assert.IsTrue(isMatching);
        }
    }
}
