
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Faker;

namespace TheWorld.Models
{
    public class WorldContextSeedData
    {
        private WorldContext _context;
        private int _trips;

        public WorldContextSeedData(WorldContext context)
        {
            _context = context;
            _trips = 5;
        }

        public async Task EnsureSeedData()
        {
            if (!_context.Trips.Any())
            {
                for (int i = 0; i <= _trips; i++)
                {
                    var trip = new Trip()
                    {
                        DateCreated = DateTime.UtcNow,
                        Name = Faker.ISOCountryCode.Next() + "Trip",
                        UserName = Faker.Internet.UserName(),
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
