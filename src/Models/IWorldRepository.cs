
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TheWorld.Models
{
    public interface IWorldRepository
    {
        IEnumerable<Trip> GetAllTrips();
        void AddTrip(Trip trip);
        Task<bool> SaveChangesAsync();
        Trip GetTripByName(string tripName);
        void AddStop(string tripName, Stop newStop, string username);
        IEnumerable<Trip> GetTripsByUsername(string username);
        Trip GetUserTripByName(string tripName, string username);
    }
}
