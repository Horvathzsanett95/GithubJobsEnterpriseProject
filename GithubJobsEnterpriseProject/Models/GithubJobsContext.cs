using Microsoft.EntityFrameworkCore;

namespace GithubJobsEnterpriseProject.Models
{
    public class GithubJobsContext : DbContext
    {
        public DbSet<GithubJob> JobItems { get; set; }
        public DbSet<Rating> Rating { get; set; }
        public DbSet<User> Users { get; set; }
        public GithubJobsContext(DbContextOptions<GithubJobsContext> options)
            : base(options)
        {
        }

        
    }
}
