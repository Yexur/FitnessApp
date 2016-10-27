using ApplicationModels.FitnessApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Logic
{
    public interface IFitnessClassLogic
    {
        //FitnessClass Get(int id);
        Task<List<FitnessClassListItem>>GetList();
        //void Save(FitnessClass fitnessClass);
        //void Delete(int id);
    }
}
