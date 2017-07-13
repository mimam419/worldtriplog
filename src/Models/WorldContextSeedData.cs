
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Faker;
using Microsoft.AspNetCore.Identity;

namespace TheWorld.Models
{
    public class WorldContextSeedData
    {
        private WorldContext _context;
        private int _trips;
        private UserManager<WorldUser> _userManager;

        public WorldContextSeedData(WorldContext context, UserManager<WorldUser> userManager)
        {
            _context = context;
            _trips = 5;
            _userManager = userManager;
        }

        public async Task EnsureSeedData()
        {
            if (await _userManager.FindByEmailAsync("mubarak@example.com") == null)
            {
                var user = new WorldUser()
                {
                    UserName = "mubarak",
                    Email = "mubarak@example.com"
                };

                await _userManager.CreateAsync(user, "P@ssw0rd!");
            }
            if (!_context.Trips.Any())
            {
                for (int i = 0; i <= _trips; i++)
                {
                    var trip = new Trip()
                    {
                        DateCreated = DateTime.UtcNow,
                        Name = Faker.ISOCountryCode.Next() + "Trip",
                        UserName = "mubarak",
                        Stops = GetRandomStops()
                    };
                    _context.Trips.AddRange(trip);
                    _context.Stops.AddRange(trip.Stops);
                }

                await _context.SaveChangesAsync();

            }
        }

        private ICollection<Stop> GetRandomStops()
        {
            var stops = new List<Stop>();
            for (int i = 0; i <= Faker.RandomNumber.Next(2, 4); i++)
            {
                var stop = new Stop()
                {
                    Name = Faker.Name.First(),
                    Longitude = Faker.RandomNumber.Next(30, 330),
                    Latitude = Faker.RandomNumber.Next(30, 330),
                    Arrival = new DateTime(2017, Faker.RandomNumber.Next(i + 5, 8), Faker.RandomNumber.Next(1, 30)),
                    Order = i
                };
                stops.Add(stop);
            }
            return stops;
        }
    }

}
