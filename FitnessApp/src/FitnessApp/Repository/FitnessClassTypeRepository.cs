using FitnessApp.IRepository;
using FitnessApp.Core;
using ApplicationModels.FitnessApp.Models;
using FitnessApp.Data;

namespace FitnessApp.Repository
{
    public class FitnessClassTypeRepository : Repository<FitnessClassType>, IFitnessClassTypeRepository
    {
        public FitnessClassTypeRepository(FitnessAppDbContext context) : base(context)
        {
        }
    }
}
