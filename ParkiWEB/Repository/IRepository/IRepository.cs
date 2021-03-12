using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkiWEB.Repository.IRepository
{
    public interface IRepository<Type> where Type : class
    {
        Task<Type> GetAsync(string url, int Id);
        Task<IEnumerable<Type>> GetAllAsync(string url);
        Task<bool> CreateAsync(string url, Type objeToCreate);
        Task<bool> UpdateAsync(string url, Type objeToUpdate);
        Task<bool> DeleteAsync(string url, int Id);

    }
}
