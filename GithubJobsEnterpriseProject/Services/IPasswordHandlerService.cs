namespace GithubJobsEnterpriseProject.Services
{
    public interface IPasswordHandlerService
    {
        public string HashUserGivenPassword(string password);
        public bool PasswordValidator(string hashedPassword, string password);
    }
}
