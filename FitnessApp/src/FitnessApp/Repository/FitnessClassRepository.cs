using FitnessApp.IRepository;
using FitnessApp.Models;
using FitnessApp.Core;

namespace FitnessApp.Repository
{
    public class FitnessClassRepository : Repository<FitnessClass>, IFitnessClassRepository
    {
        public FitnessClassRepository(FitnessAppContext context) : base(context)
        {
        }
    }
}
