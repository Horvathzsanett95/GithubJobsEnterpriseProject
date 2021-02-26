using System.ComponentModel.DataAnnotations;

namespace GithubJobsEnterpriseProject.Models
{
    public class Rating
    {
        [Key]
        public string Id { get; set; }
        public string UserId { get; set; }
        public int RatingValue { get; set; }
    }
}
