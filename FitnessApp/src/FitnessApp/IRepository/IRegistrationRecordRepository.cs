using ApplicationModels.FitnessApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessApp.IRepository
{
    public interface IRegistrationRecordRepository
    {
        Task<List<RegistrationRecord>> All();
        Task Insert(RegistrationRecord registrationRecord);
        Task InsertRange(List<RegistrationRecord> registrationRecords);
        void Delete(int id);
        void DeleteRange(int[] ids);
        RegistrationRecord FindById(int id);
        List<RegistrationRecord> FindByUserName(string userName);
    }
}
