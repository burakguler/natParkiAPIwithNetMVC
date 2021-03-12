using ParkiWEB.Models;
using ParkiWEB.Repository.IRepository;
using System.Net.Http;

namespace ParkiWEB.Repository
{
    public class NationalParkRepository : Repository<NationalPark>, INationalParkRepository
    {
        private readonly IHttpClientFactory _clientFactory;

        public NationalParkRepository(IHttpClientFactory clientFactory): base (clientFactory)
        {
            _clientFactory = clientFactory;
        }

    }
}
