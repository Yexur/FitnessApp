using ApplicationModels.FitnessApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessApp.Logic
{
    public interface IInstructorLogic
    {
        Task<Instructor> Get(int id);
        Task<List<Instructor>> GetList();
        void Save(Instructor instructor);
        void Delete(int id);
    }
}
