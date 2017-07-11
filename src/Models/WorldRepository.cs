
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace TheWorld.Models
{
    public class WorldRepository : IWorldRepository
    {
        private WorldContext _context;
        private ILogger<object> _logger;

        public WorldRepository(WorldContext context, ILogger<WorldRepository> logger)
        {
            _logger = logger;
            _context = context;
        }
        public IEnumerable<Trip> GetAllTrips()
        {
            _logger.LogInformation("Getting All trips from the Database");
            return _context.Trips.ToList();
        }
    }

}
