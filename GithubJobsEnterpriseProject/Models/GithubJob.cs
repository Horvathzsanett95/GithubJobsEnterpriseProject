using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GithubJobsEnterpriseProject.Models
{
    public class GithubJob
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public string CreatedAt { get; set; }
        public string Company { get; set; }
        public string CompanyUrl { get; set; }
        public string Location { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string HowToApply { get; set; }
        public string CompanyLogo { get; set; }
    }
}
