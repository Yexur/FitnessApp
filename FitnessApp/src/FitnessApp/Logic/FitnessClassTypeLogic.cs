using System.Linq;
using FitnessApp.IRepository;
using FitnessApp.Models;

namespace FitnessApp.Logic
{
    public class FitnessClassTypeLogic : IFitnessClassTypeLogic
    {
        private readonly IFitnessClassTypeRepository _fitnessClassTypeRepository;

        public FitnessClassTypeLogic(IFitnessClassTypeRepository fitnessClassTypeRepository)
        {
            _fitnessClassTypeRepository = fitnessClassTypeRepository;
        }

        public FitnessClassType Get(int id)
        {
            return _fitnessClassTypeRepository.FindById(id);
        }

        public IQueryable<FitnessClassType> GetList()
        {
            var fitnessClassesType = _fitnessClassTypeRepository.All();

            if (fitnessClassesType == null || !fitnessClassesType.Any())
            {
                return Enumerable.Empty<FitnessClassType> ().AsQueryable();
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
