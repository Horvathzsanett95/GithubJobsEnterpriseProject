using GithubJobsEnterpriseProject.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace GithubJobsEnterpriseProject.Services
{
    public class LoginService : ILoginService
    {
        private readonly JobContext _context;
        private readonly IPasswordHandlerService _passwordService;
        public LoginService(JobContext context, IPasswordHandlerService passwordService)
        {
            _context = context;
            _passwordService = passwordService;
        }

        public bool Login(string username, string password)
        {
            string hashedPassword;
            bool isPasswordMatching = false;

            foreach (var user in _context.Users)
            {
                if(user.Username == username)
                {
                    hashedPassword = user.Password;
                    isPasswordMatching = _passwordService.PasswordValidator(hashedPassword, password);
                }
            }
            return isPasswordMatching;
        }
    }
}
