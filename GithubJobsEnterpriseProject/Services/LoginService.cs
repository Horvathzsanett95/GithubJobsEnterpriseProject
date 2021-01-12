using GithubJobsEnterpriseProject.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace GithubJobsEnterpriseProject.Services
{
    public class LoginService
    {
        private string _username { get; set; }
        private string _password { get; set; }

        public LoginService(string username, string password)
        {
            this._password = password;
            this._username = username;
        }

        public void FindUserPassword(List<User> users)
        {
            foreach (var user in users)
            {
                if (user.Username == _username)
                {
                    _password = user.Password;
                }
            }

        }

        public bool IsUserFound(Rfc2898DeriveBytes correctPassword)
        {
            try
            {
                byte[] hashBytes = Convert.FromBase64String(_password);
                byte[] salt = new byte[16];
                Array.Copy(hashBytes, 0, salt, 0, 16);
                byte[] hash = correctPassword.GetBytes(20);

                for (int i = 0; i < 20; i++)
                {
                    if (hashBytes[i + 16] == hash[i])
                    {
                        return true;
                    }

                }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }

    }
}
