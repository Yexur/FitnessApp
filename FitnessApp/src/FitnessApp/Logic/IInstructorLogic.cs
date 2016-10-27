using ApplicationModels.FitnessApp.Models;
using System.Linq;

namespace FitnessApp.Logic
{
    public interface IInstructorLogic
    {
        Instructor Get(int id);
        IQueryable<Instructor> GetList();
        void Save(Instructor instructor);
        void Delete(int id);
    }
}
