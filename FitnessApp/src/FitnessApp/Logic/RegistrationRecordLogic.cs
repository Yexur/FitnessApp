using System.Linq;
using FitnessApp.IRepository;
using ApplicationModels.FitnessApp.Models;
using System.Collections.Generic;
using FitnessApp.Models.ApplicationViewModels;
using AutoMapper;
using System.Threading.Tasks;
using System;

namespace FitnessApp.Logic
{
    public class RegistrationRecordLogic : IRegistrationRecordLogic
    {
        private readonly IRegistrationRecordRepository _registrationRecordRepository;
        private readonly IFitnessClassRepository _fitnessClassRepository;

        public RegistrationRecordLogic(
            IRegistrationRecordRepository registrationRecordRepository,
            IFitnessClassRepository fitnessClassRepository)
        {
            _registrationRecordRepository = registrationRecordRepository;
            _fitnessClassRepository = fitnessClassRepository;
        }

        public RegistrationRecordView Get(int id)
        {
            var registrationRecord = _registrationRecordRepository.FindById(id);
            return Mapper.Map<RegistrationRecordView>(registrationRecord);
        }

        public async Task<List<RegistrationRecordView>> GetList()
        {
            var registrationRecords = await _registrationRecordRepository.All();

            if (registrationRecords == null || !registrationRecords.Any())
            {
                return Enumerable.Empty<RegistrationRecordView>().ToList();
            }
            return Mapper.Map<List<RegistrationRecordView>>(registrationRecords); ;
        }
        public List<RegistrationRecordView> FindByUserName(string userName)
        {
            var registrationRecords = _registrationRecordRepository.FindByUserName(userName);
            return Mapper.Map<List<RegistrationRecordView>>(registrationRecords);
        }

        public async Task Save(RegistrationRecordView registrationRecordView)
        {
            var registrationRecord = Mapper.Map<RegistrationRecord>(registrationRecordView);
            await _registrationRecordRepository.Insert(registrationRecord);
        }

        public async Task SaveRange(int[] fitnessClassIds, string userName)
        {
            List<RegistrationRecord> registrationRecords = new List<RegistrationRecord>();
            foreach (var fitnessClassId in fitnessClassIds)
            {
                if (_fitnessClassRepository.UpdateCapacity(fitnessClassId))
                {
                    registrationRecords.Add(new RegistrationRecord
                    {
                        Created = DateTime.Now,
                        Email = userName,
                        FitnessClass_Id = fitnessClassId,
                        UserName = userName,
                        WaitListed = false
                    });
                }
            }

            if (registrationRecords.Count() > 0)
            {
                await _registrationRecordRepository.InsertRange(registrationRecords);
            }
        }

        public void Delete(int id)
        {
            _registrationRecordRepository.Delete(id);
        }

        public void DeleteRange(int[] ids)
        {
            _registrationRecordRepository.DeleteRange(ids);
        }
    }
}
