using ParkiWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkiWEB.Repository.IRepository
{
    public interface IAccountRepository: IRepository<User>
    {
        Task<User> LoginAsync(string url, User objeToCreate);
        Task<bool> RegisterAsync(string url, User objeToCreate);
    }
}
