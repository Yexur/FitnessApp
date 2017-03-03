using FitnessApp.Models.ApplicationViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessApp.Logic
{
    public interface IFitnessClassLogic
    {
        Task<FitnessClassView> FindById(int id);
        bool FitnessClassExists(int id);
        Task<List<FitnessClassView>> GetList();
        Task<List<FitnessClassSignUpView>> GetAvailableClasses(string userName);
        Task Save(FitnessClassView fitnessClass);
        void Delete(int id);
        Task<FitnessClassView> Create();
        Task<ICollection<SelectListItem>> GetLocations();
        Task<ICollection<SelectListItem>> GetInstructors();
        Task<ICollection<SelectListItem>> GetFitnessClassTypes();
    }
}
