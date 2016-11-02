using FitnessApp.IRepository;
using FitnessApp.Core;
using ApplicationModels.FitnessApp.Models;
using FitnessApp.Data;

namespace FitnessApp.Repository
{
    public class RegistrationRecordRepository : Repository<RegistrationRecord>, IRegistrationRecordRepository
    {
        public RegistrationRecordRepository(FitnessAppDbContext context) : base(context)
        {
        }
    }
}
