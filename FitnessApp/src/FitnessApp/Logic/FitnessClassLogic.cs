using System.Linq;
using FitnessApp.IRepository;
using FitnessApp.Models;

namespace FitnessApp.Logic
{
    public class FitnessClassLogic : IFitnessClassLogic
    {
        private readonly IFitnessClassRepository _fitnessClassRepository;

        public FitnessClassLogic(IFitnessClassRepository fitnessClassRepository)
        {
            _fitnessClassRepository = fitnessClassRepository;
        }

        public FitnessClass Get(int id)
        {
            return _fitnessClassRepository.FindById(id);
        }

        public IQueryable<FitnessClass> GetList()
        {
            var fitnessClasses = _fitnessClassRepository.All();

            if (fitnessClasses == null || !fitnessClasses.Any())
            {
                return Enumerable.Empty<FitnessClass>().AsQueryable();
            }

            return fitnessClasses;
        }

        public void Save(FitnessClass fitnessClass)
        {
            _fitnessClassRepository.Insert(fitnessClass);
        }

        public void Delete(int id)
        {
            _fitnessClassRepository.Delete(id);
        }
    }
}
