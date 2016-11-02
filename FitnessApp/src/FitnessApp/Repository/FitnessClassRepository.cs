using FitnessApp.IRepository;
using FitnessApp.Core;
using ApplicationModels.FitnessApp.Models;
using FitnessApp.Data;

namespace FitnessApp.Repository
{
    public class FitnessClassRepository : Repository<FitnessClass>, IFitnessClassRepository
    {
        public FitnessClassRepository(FitnessAppDbContext context) : base(context)
        {
        }
    }
}
