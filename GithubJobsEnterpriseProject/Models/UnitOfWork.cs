using GithubJobsEnterpriseProject.Models.Repositories;

namespace GithubJobsEnterpriseProject.Models
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GithubJobsContext _context;
        public IJobRepository Jobs { get; private set; }
        public IRatingRepository Ratings { get; private set; }
        public IUserRepository Users { get; private set; }
        public UnitOfWork(GithubJobsContext context)
        {
            _context = context;
            Jobs = new JobRepository(context);
            Ratings = new RatingRepository(context);
            Users = new UserRepository(context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}
