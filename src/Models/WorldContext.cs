using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace TheWorld.Models
{
    public class WorldContext : DbContext
    {
        public WorldContext(DbContextOptions<WorldContext> options) : base(options)
        { }

        public WorldContext()
        {

        }

        public DbSet<Trip> Trips { get; set; }
        public DbSet<Stop> Stops { get; set; }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     base.OnConfiguring(optionsBuilder);
        //     var conn = _config.GetConnectionString("DefaultConnection");
        //     //optionsBuilder.UseSqlite(_config["ConnectionStrings__DefaultConnection"]);
        //     //optionsBuilder.UseSqlite("Data Source=WorldData.sqlite");
        //     optionsBuilder.UseSqlite(@"{conn}");
        // }
        // protected override void OnModelCreating(ModelBuilder builder)
        // {
        //     base.OnModelCreating(builder);
        // }
    }
}
