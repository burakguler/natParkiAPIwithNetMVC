using Newtonsoft.Json;
using ParkiWEB.Repository.IRepository;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ParkiWEB.Repository
{
    public class Repository<Type> : IRepository<Type> where Type : class
    {
        private readonly IHttpClientFactory _clientFactory;
        public Repository(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<bool> CreateAsync(string url, Type objeToCreate)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            if(objeToCreate!=null)
            {
                request.Content = new StringContent(JsonConvert.SerializeObject(objeToCreate), Encoding.UTF8, "application/json");
            }
            else
            {
                return false;
            }

            var client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if(response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                return true;
            }
            return false;

        }

        public async Task<bool> DeleteAsync(string url, int Id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, url + Id);
            var client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Type>> GetAllAsync(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Type>>(jsonString);
            }
            return null;
        }

        public async Task<Type> GetAsync(string url, int Id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url+Id);
            var client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Type>(jsonString);
            }
            return null;
        }

        public async Task<bool> UpdateAsync(string url, Type objeToUpdate)
        {
            var request = new HttpRequestMessage(HttpMethod.Patch, url);
            if (objeToUpdate != null)
            {
                request.Content = new StringContent(JsonConvert.SerializeObject(objeToUpdate), Encoding.UTF8, "application/json");
            }
            else
            {
                return false;
            }

            var client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                return true;
            }
            return false;

        }
    }
}
