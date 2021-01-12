using GithubJobsEnterpriseProject.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace GithubJobsEnterpriseProject.Services
{
    public class PasswordHandlerService
    {
        private string _password;

        public PasswordHandlerService(string password)
        {
            _password = password;
        }

        public string HashUserGivenPassword()
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(_password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            string hashedPassword = Convert.ToBase64String(hashBytes);
            return hashedPassword;
        }

        public Rfc2898DeriveBytes ConvertPasswordToByteArray()
        {
            byte[] salt = new byte[16];
            var convertedPassword = new Rfc2898DeriveBytes(_password, salt, 100000);
            return convertedPassword;
        }
    }
}
