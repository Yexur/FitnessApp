using FitnessApp.IRepository;
using FitnessApp.Models;
using FitnessApp.Core;

namespace FitnessApp.Repository
{
    public class RegistrationRecordRepository : Repository<RegistrationRecord>, IRegistrationRecordRepository
    {
        public RegistrationRecordRepository(FitnessAppContext context) : base(context)
        {
        }
    }
}
