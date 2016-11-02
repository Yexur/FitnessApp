using ApplicationModels.FitnessApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Logic
{
    public interface IRegistrationRecordLogic
    {
        Task<RegistrationRecord> Get(int id);
        Task<List<RegistrationRecord>> GetList();
        void Save(RegistrationRecord registrationRecord);
        void Delete(int id);
    }
}
