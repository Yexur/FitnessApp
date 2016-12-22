using ApplicationModels.FitnessApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Logic
{
    public interface IFitnessClassTypeLogic
    {
        FitnessClassType FindById(int id);
        Task<List<FitnessClassType>> GetList();
        Task Save(FitnessClassType fitnessClassType);
        void Delete(int id);
    }
}
