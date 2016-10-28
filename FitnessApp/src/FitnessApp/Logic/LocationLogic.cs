using System.Linq;
using FitnessApp.IRepository;
using ApplicationModels.FitnessApp.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FitnessApp.Logic
{
    public class LocationLogic : ILocationLogic
    {
        private readonly ILocationRepository _locationRepository;

        public LocationLogic(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<Location> Get(int id)
        {
            return await _locationRepository.FindById(id);
        }

        public async Task<List<Location>> GetList()
        {
            var locations = await _locationRepository.All();

            if (locations == null || !locations.Any())
            {
                return Enumerable.Empty<Location>().ToList();
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
