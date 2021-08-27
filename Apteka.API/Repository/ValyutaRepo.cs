using Apteka.API.IRepository;
using Apteka.API.Models;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apteka.API.Repository
{
    public class ValyutaRepo : IValyutaRepo
    {
        private readonly string BASE_URL;

        public ValyutaRepo(IConfiguration configuration)
        {
            BASE_URL = configuration.GetSection("API").GetSection("BaseUrl").Value;
        }

        public async Task<IEnumerable<Valyuta>> GetAllAsync()
        {
            var restClient = new RestClient(BASE_URL);

            var request = new RestRequest(Method.GET);

            var response = await restClient.GetAsync<IEnumerable<Valyuta>>(request);

            return response;
        }
    }
}
