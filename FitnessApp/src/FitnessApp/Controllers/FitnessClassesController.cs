using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FitnessApp.Logic;
using Microsoft.EntityFrameworkCore;
using FitnessApp.Models.ApplicationViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using FitnessApp.Models;

namespace FitnessApp.Controllers
{
    [Authorize]
    public class FitnessClassesController : Controller
    {
        private readonly IFitnessClassLogic _fitnessClassLogic;
        private readonly UserManager<ApplicationUser> _userManager;

        public FitnessClassesController(
            IFitnessClassLogic fitnessClassLogic,
            UserManager<ApplicationUser> userManager
        )
        {
            _fitnessClassLogic = fitnessClassLogic;
            _userManager = userManager;
        }

        
        // GET: FitnessClasses
        [Authorize(Roles = "FitnessAppAdmin")]
        public async Task<IActionResult> Index()
        {
            return View(await _fitnessClassLogic.GetList());
        }

        public async Task<IActionResult> Register()
        {
            return View(await _fitnessClassLogic.GetList());
        }


        // GET: FitnessClasses/Create
        public IActionResult Create()
        {
            return View(_fitnessClassLogic.Create());
        }

        // POST: FitnessClasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Id, StartTime, EndTime, DateOfClass, Status, Capacity, FitnessClassType, Instructor, Location")]
            FitnessClassView fitnessClass
        )
        {
            if (ModelState.IsValid)
            {
                await _fitnessClassLogic.Save(fitnessClass);
                return RedirectToAction("Index");
            } else
            {
                fitnessClass.FitnessClassTypes = _fitnessClassLogic.GetFitnessClassTypes();
                fitnessClass.Locations = _fitnessClassLogic.GetLocations();
                fitnessClass.Instructors = _fitnessClassLogic.GetInstructors();
            }
            return View(fitnessClass);
        }

        // GET: FitnessClasses/Edit/5
        public IActionResult Edit(int id)
        {
            var fitnessClass = _fitnessClassLogic.FindById(id);

            if (fitnessClass == null)
            {
                return NotFound();
            }
            return View(fitnessClass);
        }

        // POST: FitnessClasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            [Bind("Id, StartTime, EndTime, DateOfClass, Status, Capacity, FitnessClassType, Instructor, Location")]
            FitnessClassView fitnessClass
        )
        {
            //use this in the controller to filter the registration recordds returned
            //based on the username
//noit actaullt needed here
            var user = await _userManager.FindByNameAsync(this.User.Identity.Name);

            if (id != fitnessClass.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _fitnessClassLogic.Save(fitnessClass);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_fitnessClassLogic.FitnessClassExists(fitnessClass.Id))
                    {
                        return NotFound();
                    } else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            } else
            {
                fitnessClass.Locations = _fitnessClassLogic.GetLocations();
                fitnessClass.Instructors = _fitnessClassLogic.GetInstructors();
                fitnessClass.FitnessClassTypes = _fitnessClassLogic.GetFitnessClassTypes();
            }
            return View(fitnessClass);
        }

        // GET: FitnessClasses/Delete/5
        public IActionResult Delete(int id)
        {
            var fitnessClass = _fitnessClassLogic.FindById(id);

            if (fitnessClass == null)
            {
                return NotFound();
            }
            return View(fitnessClass);
        }

        // POST: FitnessClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _fitnessClassLogic.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
