using ApplicationModels.FitnessApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Logic
{
    public interface IFitnessClassTypeLogic
    {
        Task<FitnessClassType> Get(int id);
        Task<List<FitnessClassType>> GetList();
        void Save(FitnessClassType fitnessClassType);
        void Delete(int id);
    }
}
