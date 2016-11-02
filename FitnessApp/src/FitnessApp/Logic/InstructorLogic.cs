using System.Linq;
using FitnessApp.IRepository;
using ApplicationModels.FitnessApp.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FitnessApp.Logic
{
    public class InstructorLogic : IInstructorLogic
    {
        private readonly IInstructorRepository _instructorRepository;

        public InstructorLogic(IInstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }

        public async Task<Instructor> Get(int id)
        {
            return await _instructorRepository.FindById(id);
        }

        public async Task<List<Instructor>> GetList()
        {
            var instructors = await _instructorRepository.All();

            if (instructors == null || !instructors.Any())
            {
                return Enumerable.Empty<Instructor>().ToList();
            }

            return instructors;
        }

        public void Save(Instructor instructor)
        {
            _instructorRepository.Insert(instructor);
        }

        public void Delete(int id)
        {
            _instructorRepository.Delete(id);
        }
    }
}
