using FitnessApp.IRepository;
using FitnessApp.Models;
using FitnessApp.Core;

namespace FitnessApp.Repository
{
    public class InstructorRepository : Repository<Instructor>, IInstructorRepository
    {
        public InstructorRepository(FitnessAppContext context) : base(context)
        {
        }
    }
}
