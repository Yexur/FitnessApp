using FitnessApp.Models;
using System.Linq;

namespace FitnessApp.Logic
{
    public interface ILocationLogic
    {
        Location Get(int id);
        IQueryable<Location> GetList();
        void Save(Location location);
        void Delete(int id);
    }
}
