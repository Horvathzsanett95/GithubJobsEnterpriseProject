using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
