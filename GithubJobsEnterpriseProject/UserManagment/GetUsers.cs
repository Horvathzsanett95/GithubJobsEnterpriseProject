using GithubJobsEnterpriseProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace GithubJobsEnterpriseProject.UserManagment
{
    public class GetUsers
    {
        IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);
        public List<User> DeconvertUsersJson()
        {
            if (isoStore.FileExists("users.json"))
            {
                Console.WriteLine("The file already exists!");
                using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream("users.json", FileMode.Open, isoStore))
                {
                    using (StreamReader reader = new StreamReader(isoStream))
                    {
                        string jsonString;
                        jsonString = reader.ReadToEnd();
                        var users = JsonSerializer.Deserialize<List<User>>(jsonString); // needs fix;
                        return users;
                    }
                }
            }
            return null;
        }
    }
}
