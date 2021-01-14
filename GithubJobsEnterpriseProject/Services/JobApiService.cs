using GithubJobsEnterpriseProject.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace GithubJobsEnterpriseProject.Controllers
{
    public class JobApiService : IJobApiService
    {
        IConfiguration _iconfig;
        public JobApiService(IConfiguration iconfig)
        {
            _iconfig = iconfig;
        }

        private string _urlParameters;

        public Appsettings GetLink()
        {
            Appsettings appsettings = new Appsettings();
            appsettings.Url = _iconfig.GetValue<string>("GithubJobs:Url");
            appsettings.BaseUrl = _iconfig.GetValue<string>("GithubJobs:BaseUrl");
            return appsettings;
        }

        public IEnumerable<GithubJob> GetGithubJobsFromUrl()
        {
            string url = GetLink().Url;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync(_urlParameters).Result;
                if (response.IsSuccessStatusCode)
                {
                    var dataObjects = response.Content.ReadAsAsync<IEnumerable<GithubJob>>().Result;
                    
                    return dataObjects;
                }
                else
                {
                    Console.WriteLine($"{response.StatusCode} ({response.ReasonPhrase})");
                }
                return null;
            }
        }

        public IEnumerable<GithubJob> GetGithubJobsByParameters(string descriptionParameter, string locationParameter)
        {
            string url = GetLink().BaseUrl;
            _urlParameters = "positions.json?description=" + descriptionParameter + "&location=" + locationParameter;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync(_urlParameters).Result;
                if (response.IsSuccessStatusCode)
                {
                    var dataObjects = response.Content.ReadAsAsync<IEnumerable<GithubJob>>().Result;
                    return dataObjects;
                }
                else
                {
                    Console.WriteLine($"{response.StatusCode} ({response.ReasonPhrase})");
                }
                return null;
            }
        }
    }
}
