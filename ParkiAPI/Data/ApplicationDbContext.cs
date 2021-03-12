using Microsoft.EntityFrameworkCore;
using ParkiAPI.Models;

namespace ParkiAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<NationalPark> NationalPark { get; set; }
        public DbSet<Trail> Trails { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
