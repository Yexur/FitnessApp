using System.Linq;
using FitnessApp.IRepository;
using FitnessApp.Models;

namespace FitnessApp.Logic
{
    public class LocationLogic : ILocationLogic
    {
        private readonly ILocationRepository _locationRepository;

        public LocationLogic(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public Location Get(int id)
        {
            return _locationRepository.FindById(id);
        }

        public IQueryable<Location> GetList()
        {
            var locations = _locationRepository.All();

            if (locations == null || !locations.Any())
            {
                return Enumerable.Empty<Location>().AsQueryable();
            }

            return locations;
        }

        public void Save(Location location)
        {
            _locationRepository.Insert(location);
        }

        public void Delete(int id)
        {
            _locationRepository.Delete(id);
        }
    }
}
