using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkiWEB.Repository.IRepository
{
    public interface IRepository<Type> where Type : class
    {
        Task<Type> GetAsync(string url, int Id, string token);
        Task<IEnumerable<Type>> GetAllAsync(string url, string token);
        Task<bool> CreateAsync(string url, Type objeToCreate, string token);
        Task<bool> UpdateAsync(string url, Type objeToUpdate, string token);
        Task<bool> DeleteAsync(string url, int Id, string token);

    }
}
