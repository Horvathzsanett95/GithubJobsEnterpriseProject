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
    public class SaveUser
    {
        IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);

        public void ConvertUserToJson(User user)
        {
            if (isoStore.FileExists("users.json"))
            {
                using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream("users.json", FileMode.Append, isoStore))
                {
                    using (StreamWriter writer = new StreamWriter(isoStream))
                    {
                        writer.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(user));
                    }
                }
            }
            else if(!isoStore.FileExists("users.json"))
            {
                using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream("users.json", FileMode.CreateNew, isoStore))
                {
                    using (StreamWriter writer = new StreamWriter(isoStream))
                    {
                        writer.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(user));
                    }
                }

            }
        }
    }
}
