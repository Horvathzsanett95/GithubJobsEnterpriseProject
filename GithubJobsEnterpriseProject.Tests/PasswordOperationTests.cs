using GithubJobsEnterpriseProject.Utilities;
using NUnit.Framework;

namespace GithubJobsEnterpriseProject.Tests
{
    class PasswordOperationTests
    {
        [Test]
        public void EncryptPasswordToHashCodeShouldReturnSafePasswordTest()
        {
            string password = "123";
            string hashedPwd = PasswordOperations.HashUserGivenPassword(password);
            Assert.AreNotEqual(hashedPwd, password);
            Assert.IsTrue(hashedPwd.Length > password.Length);
        }

        [Test]
        public void DecríptPasswordFromHashReturnsTrueTest()
        {
            string password = "123";
            string hashedPwd = PasswordOperations.HashUserGivenPassword(password);
            bool isMatching = PasswordOperations.PasswordValidator(hashedPwd, password);
            Assert.IsTrue(isMatching);
        }
    }
}
