using System.Linq;
using FitnessApp.IRepository;
using ApplicationModels.FitnessApp.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FitnessApp.Logic
{
    public class FitnessClassTypeLogic : IFitnessClassTypeLogic
    {
        private readonly IFitnessClassTypeRepository _fitnessClassTypeRepository;

        public FitnessClassTypeLogic(IFitnessClassTypeRepository fitnessClassTypeRepository)
        {
            _fitnessClassTypeRepository = fitnessClassTypeRepository;
        }

        public async Task<FitnessClassType> Get(int id)
        {
            return await _fitnessClassTypeRepository.FindById(id);
        }

        public async Task<List<FitnessClassType>> GetList()
        {
            var fitnessClassesType = await _fitnessClassTypeRepository.All();

            if (fitnessClassesType == null || !fitnessClassesType.Any())
            {
                return Enumerable.Empty<FitnessClassType> ().ToList();
            }

            return fitnessClassesType;
        }

        public void Save(FitnessClassType fitnessClassType)
        {
            _fitnessClassTypeRepository.Insert(fitnessClassType);
        }

        public void Delete(int id)
        {
            _fitnessClassTypeRepository.Delete(id);
        }
    }
}
