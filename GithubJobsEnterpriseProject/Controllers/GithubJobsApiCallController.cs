using GithubJobsEnterpriseProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace GithubJobsEnterpriseProject.Controllers
{
    public class GithubJobsApiCallController
    {
        private const string _url = "https://jobs.github.com/positions.json";
        private string _urlParameters;
        public GithubJobsApiCallController()
        {
            
        }

        public IEnumerable<GithubJob> GetGithubJobsFromUrl ()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_url);

            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(_urlParameters).Result;
            if (response.IsSuccessStatusCode)
            {
                var dataObjects = response.Content.ReadAsAsync<IEnumerable<GithubJob>>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                return dataObjects;

            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                
            }
            client.Dispose();
            return null;
            
            
        }

        
    }
}
