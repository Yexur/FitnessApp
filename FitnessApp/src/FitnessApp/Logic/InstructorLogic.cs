using System.Linq;
using FitnessApp.IRepository;
using ApplicationModels.FitnessApp.Models;

namespace FitnessApp.Logic
{
    public class InstructorLogic : IInstructorLogic
    {
        private readonly IInstructorRepository _instructorRepository;

        public InstructorLogic(IInstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }

        public Instructor Get(int id)
        {
            return _instructorRepository.FindById(id);
        }

        public IQueryable<Instructor> GetList()
        {
            var instructors = _instructorRepository.All();

            if (instructors == null || !instructors.Any())
            {
                return Enumerable.Empty<Instructor>().AsQueryable();
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
