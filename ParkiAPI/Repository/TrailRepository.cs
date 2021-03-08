using Microsoft.EntityFrameworkCore;
using ParkiAPI.Data;
using ParkiAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkiAPI.Repository.IRepository
{
    public class TrailRepository : ITrailRepository
    {
        private readonly ApplicationDbContext _db;
        public TrailRepository(ApplicationDbContext db) //dependency injection ~Burak
        {
            _db = db;
        }

        public bool CreateTrail(Trail trail)   //Create
        {
            _db.Trails.Add(trail);
            return Save();
        }

        public Trail GetTrail(int trailId)     //Read(select by Id)
        {
            return _db.Trails.Include(c => c.NationalPark).FirstOrDefault(a => a.Id == trailId);
        }
        public ICollection<Trail> GetTrails()
        {
            return _db.Trails.Include(c => c.NationalPark).OrderBy(a => a.Name).ToList();  //Read(select by name)
        }
        public ICollection<Trail> GetTrailsInNationalPark(int nationalParkId)
        {
            return _db.Trails.Include(c => c.NationalPark).Where(c => c.NationalParkId ==nationalParkId).ToList();
        }
        public bool UpdateTrail(Trail trail)  //Update
        {
            _db.Trails.Update(trail);
            return Save();
        }
        public bool DeleteTrail(Trail trail)  //Delete
        {
            _db.Trails.Remove(trail);
            return Save();
        }

        public bool TrailExists(string name)
        {
            bool value = _db.Trails.Any(a => a.Name.ToLower().Trim() == name.ToLower().Trim());
            return value;
        }

        public bool TrailExists(int id)
        {
            return _db.Trails.Any(a => a.Id == id);
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

       
    }
}
