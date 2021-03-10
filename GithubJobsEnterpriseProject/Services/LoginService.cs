using GithubJobsEnterpriseProject.Models;
using GithubJobsEnterpriseProject.Utilities;

namespace GithubJobsEnterpriseProject.Services
{
    public class LoginService : ILoginService
    {
        private readonly GithubJobsContext _context;
        public LoginService(GithubJobsContext context)
        {
            _context = context;
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
                    isPasswordMatching = PasswordOperations.PasswordValidator(hashedPassword, password);
                }
            }
            return isPasswordMatching;
        }
    }
}
