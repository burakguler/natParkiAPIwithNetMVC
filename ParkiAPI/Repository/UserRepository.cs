using ParkiAPI.Data;
using ParkiAPI.Models;
using ParkiAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkiAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext dbContext;
        public UserRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public User Authenticate(string username, string password)
        {
            throw new NotImplementedException();
        }

        public bool IsUniqueUser(string username)
        {
            throw new NotImplementedException();
        }

        public User Register(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
