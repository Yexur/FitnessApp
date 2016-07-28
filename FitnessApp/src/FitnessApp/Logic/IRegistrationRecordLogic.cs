using FitnessApp.Models;
using System.Linq;

namespace FitnessApp.Logic
{
    public interface IRegistrationRecordLogic
    {
        RegistrationRecord Get(int id);
        IQueryable<RegistrationRecord> GetList();
        void Save(RegistrationRecord registrationRecord);
        void Delete(int id);
    }
}
