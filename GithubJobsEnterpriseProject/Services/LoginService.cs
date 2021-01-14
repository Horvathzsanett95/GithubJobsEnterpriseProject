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
        private List<User> _userList { get; set; }

        public LoginService(string username, string password,List<User> users)
        {
            this._password = password;
            this._username = username;
            this._userList = users;
        }

        public bool Login()
        {
            string savedPasswordHash = "";

            foreach (var user in _userList)
            {
                if(user.Username == _username)
                {
                    savedPasswordHash = user.Password;
                }
            }

            byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);

            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            var pbkdf2 = new Rfc2898DeriveBytes(_password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);

            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return false;

        }
    }
}
