using ApplicationModels.FitnessApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Logic
{
    public interface ILocationLogic
    {
        Task<Location> Get(int id);
        Task<List<Location>> GetList();
        void Save(Location location);
        void Delete(int id);
    }
}
