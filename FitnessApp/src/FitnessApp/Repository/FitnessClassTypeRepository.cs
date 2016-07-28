using FitnessApp.IRepository;
using FitnessApp.Models;
using FitnessApp.Core;

namespace FitnessApp.Repository
{
    public class FitnessClassTypeRepository : Repository<FitnessClassType>, IFitnessClassTypeRepository
    {
        public FitnessClassTypeRepository(FitnessAppContext context) : base(context)
        {
        }
    }
}
