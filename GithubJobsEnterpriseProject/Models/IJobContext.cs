using Microsoft.EntityFrameworkCore;

namespace GithubJobsEnterpriseProject.Models
{
    public interface IJobContext
    {
        DbSet<GithubJob> JobItems { get; set; }
    }
}