using ApplicationModels.FitnessApp.Models;
using System.Linq;

namespace FitnessApp.Logic
{
    public interface IFitnessClassTypeLogic
    {
        FitnessClassType Get(int id);
        IQueryable<FitnessClassType> GetList();
        void Save(FitnessClassType fitnessClassType);
        void Delete(int id);
    }
}
