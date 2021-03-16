using Newtonsoft.Json;
using ParkiWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ParkiWEB.Repository.IRepository
{
    public class AccountRepository : Repository<User>, IAccountRepository
    {
        private readonly IHttpClientFactory _clientFactory;

        public AccountRepository(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<User> LoginAsync(string url, User objeToCreate)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            if (objeToCreate != null)
            {
                request.Content = new StringContent(JsonConvert.SerializeObject(objeToCreate), Encoding.UTF8, "application/json");
            }
            else
            {
                return new User();
            }

            var client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<User>(jsonString);
            }
            return new User();
        }

        public async Task<bool> RegisterAsync(string url, User objeToCreate)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            if (objeToCreate != null)
            {
                request.Content = new StringContent(JsonConvert.SerializeObject(objeToCreate), Encoding.UTF8, "application/json");
            }
            else
            {
                return false;
            }

            var client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }
    }
}
