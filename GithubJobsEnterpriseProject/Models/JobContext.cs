using Microsoft.EntityFrameworkCore;

namespace GithubJobsEnterpriseProject.Models
{
    public class JobContext : DbContext
    {
        public DbSet<GithubJob> JobItems { get; set; }
        public DbSet<Rating> Rating { get; set; }
        public DbSet<User> Users { get; set; }
        public JobContext(DbContextOptions<JobContext> options)
            : base(options)
        {
        }

        
    }
}
