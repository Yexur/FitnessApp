using FitnessApp.IRepository;
using FitnessApp.Models;
using FitnessApp.Core;

namespace FitnessApp.Repository
{
    public class LocationRepository : Repository<Location>, ILocationRepository
    {
        public LocationRepository(FitnessAppContext context) : base(context)
        {
        }
    }
}
