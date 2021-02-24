using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GithubJobsEnterpriseProject.Services
{
    public interface IPasswordHandlerService
    {
        public string HashUserGivenPassword(string password);
        public bool PasswordValidator(string hashedPassword, string password);
    }
}
