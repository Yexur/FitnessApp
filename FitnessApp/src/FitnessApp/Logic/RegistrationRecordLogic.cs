using System.Linq;
using FitnessApp.IRepository;
using ApplicationModels.FitnessApp.Models;

namespace FitnessApp.Logic
{
    public class RegistrationRecordLogic : IRegistrationRecordLogic
    {
        private readonly IRegistrationRecordRepository _registrationRecordRepository;

        public RegistrationRecordLogic(IRegistrationRecordRepository registrationRecordRepository)
        {
            _registrationRecordRepository = registrationRecordRepository;
        }

        public RegistrationRecord Get(int id)
        {
            return _registrationRecordRepository.FindById(id);
        }

        public IQueryable<RegistrationRecord> GetList()
        {
            var registrationRecords = _registrationRecordRepository.All();

            if (registrationRecords == null || !registrationRecords.Any())
            {
                return Enumerable.Empty<RegistrationRecord>().AsQueryable();
            }

            return registrationRecords;
        }

        public void Save(RegistrationRecord registrationRecord)
        {
            _registrationRecordRepository.Insert(registrationRecord);
        }

        public void Delete(int id)
        {
            _registrationRecordRepository.Delete(id);
        }
    }
}
