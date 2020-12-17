using GithubJobsEnterpriseProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace GithubJobsEnterpriseProject.UserManagment
{
    public class LoginManager
    {
        private List<User> _users = new GetUsers().DeconvertUsersJson();

        public bool getLogin(string username, string password)
        {
            string userPassword = "";

            foreach (var user in _users)
            {
                if (user.Username == username)
                {
                    userPassword = user.Password;
                }
            }

            /* Fetch the stored value */
            /* Extract the bytes */
            byte[] hashBytes = Convert.FromBase64String(userPassword);
            /* Get the salt */
            byte[] salt = new byte[16];
            try { 
                Array.Copy(hashBytes, 0, salt, 0, 16);
                /* Compute the hash on the password the user entered */
                var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
                byte[] hash = pbkdf2.GetBytes(20);
                /* Compare the results */
                for (int i = 0; i < 20; i++) {
                    if (hashBytes[i + 16] == hash[i])
                    {
                        return true;
                    }
                        
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
