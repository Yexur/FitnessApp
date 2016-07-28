using FitnessApp.Models;
using System.Linq;

namespace FitnessApp.Logic
{
    public interface IFitnessClassLogic
    {
        FitnessClass Get(int id);
        IQueryable<FitnessClass> GetList();
        void Save(FitnessClass fitnessClass);
        void Delete(int id);
    }
}
