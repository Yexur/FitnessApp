using System.Threading.Tasks;
using ApplicationModels.FitnessApp.Models;
using FitnessApp.Core;
using System.Collections.Generic;

namespace FitnessApp.IRepository
{
    public interface IFitnessClassRepository //: IRepository<FitnessClass>
    {
        Task<List<FitnessClass>> All();
    }
}
