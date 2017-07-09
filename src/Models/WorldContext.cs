using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace TheWorld.Models
{
    public class WorldContext : DbContext
    {
        private IConfiguration _config;

        public WorldContext(DbContextOptions options, IConfiguration config) : base(options)
        {
            _config = config;
        }

        public WorldContext()
        {

        }

        public DbSet<Trip> Trips { get; set; }
        public DbSet<Stop> Stops { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var conn = _config.GetConnectionString("DefaultConnection");
            //optionsBuilder.UseSqlite(_config["ConnectionStrings__DefaultConnection"]);
            //optionsBuilder.UseSqlite("Data Source=WorldData.sqlite");
            optionsBuilder.UseSqlite(@"{conn}");
        }
    }
}
