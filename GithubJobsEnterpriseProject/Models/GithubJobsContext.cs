using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GithubJobsEnterpriseProject.Models
{
    public class GithubJobsContext : IdentityDbContext
    {
        public DbSet<GithubJob> JobItems { get; set; }
        public DbSet<Rating> Rating { get; set; }
        new public DbSet<User> Users { get; set; }
        public GithubJobsContext(DbContextOptions<GithubJobsContext> options)
            : base(options)
        {
        }


    }
}
