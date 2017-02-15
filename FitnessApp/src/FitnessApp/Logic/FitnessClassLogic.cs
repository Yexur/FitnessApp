using ApplicationModels.FitnessApp.Models;
using FitnessApp.IRepository;
using FitnessApp.Models.ApplicationViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using AutoMapper;


//create a new view model with the attending field
//then we can pass this back to the controller
//move this call to the registration controller
//it can do the work of checking the attending and the number of people
//registered
//the view model will also calcualte the number of people already registered
//it will also only get the active classes
//if there is room in the fitness class we will create a registration record
//add a view for the registration records that will have the ability to delete a registration via a check box
//ask to confirm and then delete
//later this will be filtered by the logedin user
// get the registration by e-mail
//addd to the services to haVE A unique e-mail and get by the user name the registrations
//use this to set the name of the registration as well

namespace FitnessApp.Logic
{
    public class FitnessClassLogic : IFitnessClassLogic
    {
        private readonly IFitnessClassRepository _fitnessClassRepository;
        private readonly IInstructorLogic _instructorLogic;
        private readonly IFitnessClassTypeLogic _fitnessClassTypeLogic;
        private readonly ILocationLogic _locationLogic;

        public FitnessClassLogic(
            IFitnessClassRepository fitnessClassRepository,
            IInstructorLogic instructorLogic,
            IFitnessClassTypeLogic fitnessClassTypeLogic,
            ILocationLogic locationLogic
        )
        {
            _fitnessClassRepository = fitnessClassRepository;
            _instructorLogic = instructorLogic;
            _fitnessClassTypeLogic = fitnessClassTypeLogic;
            _locationLogic = locationLogic;
        }

        public FitnessClassView Create()
        {
            return new FitnessClassView
            {
                FitnessClassTypes = GetFitnessClassTypes(),
                Locations = GetLocations(),
                Instructors = GetInstructors()
            };
        }

        public FitnessClassView FindById(int id)
        {
            var fitnessClass = _fitnessClassRepository.FindById(id);
            var fitnessClassView = Mapper.Map<FitnessClassView>(fitnessClass);
            fitnessClassView.FitnessClassTypes = GetFitnessClassTypes();
            fitnessClassView.Instructors = GetInstructors();
            fitnessClassView.Locations = GetLocations();
            return fitnessClassView;
        }

        public async Task<List<FitnessClassView>> GetList()
        {
            var fitnessClasses = await _fitnessClassRepository.All();

            if (fitnessClasses == null || !fitnessClasses.Any())
            {
                return Enumerable.Empty<FitnessClassView>().ToList();
            }
            return Mapper.Map<List<FitnessClassView>>(fitnessClasses);
        }

        //this is not correct it needs to check on capacity and filter by active etc 
        public async Task<List<FitnessClassSignUpView>> GetAvailableClasses()
        {
            var fitnessClasses = await _fitnessClassRepository.All();

            if (fitnessClasses == null || !fitnessClasses.Any())
            {
                return Enumerable.Empty<FitnessClassSignUpView>().ToList();
            }
            return Mapper.Map<List<FitnessClassSignUpView>>(fitnessClasses);
        }

        //we will use a new method that the registration logic can access to update the
        //fitness class capacity
        public async Task Save(FitnessClassView fitnessClassView)
        {
            var fitnessClass = Mapper.Map<FitnessClass>(fitnessClassView);
            await _fitnessClassRepository.Insert(fitnessClass);
        }

        public void Delete(int id)
        {
            _fitnessClassRepository.Delete(id);
        }

        public bool FitnessClassExists(int id)
        {
            return _fitnessClassRepository.FitnessClassExists(id);
        }

        public ICollection<SelectListItem> GetLocations()
        {
            var locations = _locationLogic.GetList();
            var locationSelectList = locations.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            });
            return BuildSelectListItems(locationSelectList);
        }

        public ICollection<SelectListItem> GetInstructors()
        {
            var instructors = _instructorLogic.GetList();
            var instructorSelectList = instructors.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            });
            return BuildSelectListItems(instructorSelectList);
        }

        public ICollection<SelectListItem> GetFitnessClassTypes()
        {
            var fitnessClassTypes = _fitnessClassTypeLogic.GetList();
            var fitnessClassTypesSelectList = fitnessClassTypes.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            });
            return BuildSelectListItems(fitnessClassTypesSelectList);
        }

        private SelectListItem AddDefaultSelectItem()
        {
            return new SelectListItem
            {
                Value = "",
                Text = "Please Select an Item"
            };
        }

        private ICollection<SelectListItem> BuildSelectListItems(IEnumerable<SelectListItem> list)
        {
            List<SelectListItem> selectList = new List<SelectListItem>();
            selectList.Add(AddDefaultSelectItem());
            selectList.AddRange(list);
            return selectList;
        }
    }
}
