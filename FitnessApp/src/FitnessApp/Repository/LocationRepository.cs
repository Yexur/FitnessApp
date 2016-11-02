using FitnessApp.IRepository;
using FitnessApp.Core;
using ApplicationModels.FitnessApp.Models;
using FitnessApp.Data;

namespace FitnessApp.Repository
{
    public class LocationRepository : Repository<Location>, ILocationRepository
    {
        public LocationRepository(FitnessAppDbContext context) : base(context)
        {
        }
    }
}
