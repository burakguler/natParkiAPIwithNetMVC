using ParkiWEB.Models;
using ParkiWEB.Repository.IRepository;
using System.Net.Http;


namespace ParkiWEB.Repository
{
    public class TrailRepository : Repository<Trail>, ITrailRepository
    {
        private readonly IHttpClientFactory _clientFactory;
        public TrailRepository(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
    }
}
