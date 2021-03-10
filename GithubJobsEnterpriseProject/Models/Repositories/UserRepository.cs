namespace GithubJobsEnterpriseProject.Models.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(GithubJobsContext context)
            : base(context)
        {

        }
    }
}
