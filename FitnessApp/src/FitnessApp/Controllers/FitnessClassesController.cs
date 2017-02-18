using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FitnessApp.Logic;
using Microsoft.EntityFrameworkCore;
using FitnessApp.Models.ApplicationViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using FitnessApp.Models;
using System.Collections.Generic;

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
            _userManager = userManager;  //this will be used during the save to get the username and add that to the request to save the registration
        }

        // GET: FitnessClasses
        [Authorize(Roles = "FitnessAppAdmin")]
        public async Task<IActionResult> Index()
        {
            return View(await _fitnessClassLogic.GetList());
        }

        // GET: Available FitnessClasses
        public async Task<IActionResult> SignUp()
        {
            return View(await _fitnessClassLogic.GetAvailableClasses());
        }

        //POST: FitnessClasses/SignUp
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(string[] attendingSelected)
        {
            foreach (var item in attendingSelected)
            {
                var i = item;
            }
            //this will need to do several things after this
                //save the registrations
                //update the remaining capacity
                //and filter the list by the class already signed up for
                
            return View(await _fitnessClassLogic.GetAvailableClasses());
        }

        // GET: FitnessClasses/Create
        [Authorize(Roles = "FitnessAppAdmin")]
        public IActionResult Create()
        {
            return View(_fitnessClassLogic.Create());
        }

        // POST: FitnessClasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "FitnessAppAdmin")]
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
        [Authorize(Roles = "FitnessAppAdmin")]
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
        [Authorize(Roles = "FitnessAppAdmin")]
        public async Task<IActionResult> Edit(
            int id,
            [Bind("Id, StartTime, EndTime, DateOfClass, Status, Capacity, FitnessClassType, Instructor, Location")]
            FitnessClassView fitnessClass
        )
        {
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
        [Authorize(Roles = "FitnessAppAdmin")]
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
        [Authorize(Roles = "FitnessAppAdmin")]
        public IActionResult DeleteConfirmed(int id)
        {
            _fitnessClassLogic.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
