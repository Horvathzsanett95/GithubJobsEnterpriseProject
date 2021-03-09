using System.ComponentModel.DataAnnotations;

namespace GithubJobsEnterpriseProject.Models
{
    public class User
    {
        public User(string username, string email, string password)
        {
            Username = username;
            Email = email;
            Password = password;
        }
        [Key]
        public int userId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }



    }
}
