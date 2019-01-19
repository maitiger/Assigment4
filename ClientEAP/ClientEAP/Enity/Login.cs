using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.Enity
{
    class Login
    {
      
  
        private string _email;
        private string _password;
        public string email { get => _email; set => _email = value; }
        public string password { get => _password; set => _password = value; }
        public static async Task<StudentRoll> GetInformation(string token)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Basic " + token);
            var response = client.GetAsync(Service.API_INFORMATION);
            Debug.WriteLine(response.Result.StatusCode);
            var result = await response.Result.Content.ReadAsStringAsync();
            StudentRoll responseJsonMember = JsonConvert.DeserializeObject<StudentRoll>(result);
            return responseJsonMember;
        }
    }
}
