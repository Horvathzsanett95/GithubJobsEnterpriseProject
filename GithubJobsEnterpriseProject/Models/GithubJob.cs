﻿using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GithubJobsEnterpriseProject.Models
{
    public class GithubJob
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Type { get; set; }
        public string Url { get; set; }
        [JsonProperty(PropertyName = "created_at")]
        public string CreatedAt { get; set; }
        [Required]
        public string Company { get; set; }
        [JsonProperty(PropertyName = "company_url")]
        public string CompanyUrl { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [JsonProperty(PropertyName = "how_to_apply")]
        public string HowToApply { get; set; }
        [JsonProperty(PropertyName = "company_logo")]
        public string CompanyLogo { get; set; }
        public bool IsMarked { get; set; }
    }
}
