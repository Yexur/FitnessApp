using ApplicationModels.FitnessApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessApp.Logic
{
    public interface IFitnessClassLogic
    {
        Task<FitnessClass> Get(int id);
        Task<List<FitnessClassListItem>>GetList();
        void Save(FitnessClass fitnessClass);
        void Delete(int id);
    }
}
