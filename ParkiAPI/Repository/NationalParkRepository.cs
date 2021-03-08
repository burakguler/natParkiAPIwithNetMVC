using ParkiAPI.Data;
using ParkiAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkiAPI.Repository.IRepository
{
    public class NationalParkRepository : INationalParkRepository
    {
        private readonly ApplicationDbContext _db;
        public NationalParkRepository(ApplicationDbContext db) //dependency injection ~Burak
        {
            _db = db;
        }

        public bool CreateNationalPark(NationalPark nationalPark)   //Create
        {
            _db.NationalPark.Add(nationalPark);
            return Save();
        }

        public NationalPark GetNationalPark(int nationalParkId)     //Read(select by Id)
        {   
            return _db.NationalPark.FirstOrDefault(a => a.Id == nationalParkId);
        }

        public ICollection<NationalPark> GetNationalParks()
        {
            return _db.NationalPark.OrderBy(a => a.Name).ToList();  //Read(select by name)
        }

        public bool UpdateNationalPark(NationalPark nationalPark)  //Update
        {
            _db.NationalPark.Update(nationalPark);
            return Save();
        }
        public bool DeleteNationalPark(NationalPark nationalPark)  //Delete
        {
            _db.NationalPark.Remove(nationalPark);
            return Save();
        }

        public bool NationalParkExists(string name)
        {
            bool value = _db.NationalPark.Any(a => a.Name.ToLower().Trim() == name.ToLower().Trim());
            return value;
        }

        public bool NationalParkExists(int id)
        {
            return _db.NationalPark.Any(a => a.Id == id);
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }
              
    }
}
