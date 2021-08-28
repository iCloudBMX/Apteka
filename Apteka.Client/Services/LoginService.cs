using Apteka.API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Apteka.Client.Models;

namespace Apteka.Client.Services
{
    class LoginService : IApiService<Login>
    {
        public Task<IEnumerable<Login>> Get()
        {
            throw new NotImplementedException();
        }

        public async Task<string> Post(Login entity)
        {
            using(var client = new HttpClient())
            {
                var serilizedData = JsonConvert.SerializeObject(entity);

                var content = new StringContent(serilizedData, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(Constants.LOGIN, content);

                if(response.StatusCode == System.Net.HttpStatusCode.Accepted)
                {
                    return await response.Content.ReadAsStringAsync();
                }

                return null;
            }
        }
    }
}
