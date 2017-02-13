using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApplicationModels.FitnessApp.Models;
using FitnessApp.Data;
using Microsoft.AspNetCore.Authorization;

//create a new view model with the attending field
//then we can pass this back to the controller
//move this call to the registration controller
//it can do the work of checking the attending and the number of people
//registered
//the view model will also calcualte the number of people already registered
//if there is room we will create a registration record
//add a view for the registration records that will have the ability to delete a registration via a check box
//ask to confirm and then delete
//later this will be filtered by the logedin user
//the registration record needs to have an account id from the registration
//need to add a id to the identiy table to hold the id of the user so we can add it to the registrations - do not need this
// get the registration by e-mail
//addd to the services to haVE A unique e-mail and get by the user name the registrations
//use this to set the name of the registration as well

namespace FitnessApp.Controllers
{
    [Authorize]
    public class RegistrationRecordsController : Controller
    {
        private readonly FitnessAppDbContext _context;

        public RegistrationRecordsController(FitnessAppDbContext context)
        {
            _context = context;
        }

        // GET: RegistrationRecords
        public async Task<IActionResult> Index()
        {
            var fitnessAppDbContext = _context.RegistrationRecord.Include(r => r.FitnessClass);
            return View(await fitnessAppDbContext.ToListAsync());
        }

        // GET: RegistrationRecords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registrationRecord = await _context.RegistrationRecord.SingleOrDefaultAsync(m => m.Id == id);
            if (registrationRecord == null)
            {
                return NotFound();
            }

            return View(registrationRecord);
        }

        // GET: RegistrationRecords/Create
        public IActionResult Create()
        {
            ViewData["FitnessClass_Id"] = new SelectList(_context.FitnessClass, "Id", "Id");
            return View();
        }

        // POST: RegistrationRecords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Created,Email,FitnessClass_Id,Name,Updated,WaitListed")] RegistrationRecord registrationRecord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registrationRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["FitnessClass_Id"] = new SelectList(_context.FitnessClass, "Id", "Id", registrationRecord.FitnessClass_Id);
            return View(registrationRecord);
        }

        // GET: RegistrationRecords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registrationRecord = await _context.RegistrationRecord.SingleOrDefaultAsync(m => m.Id == id);
            if (registrationRecord == null)
            {
                return NotFound();
            }
            ViewData["FitnessClass_Id"] = new SelectList(_context.FitnessClass, "Id", "Id", registrationRecord.FitnessClass_Id);
            return View(registrationRecord);
        }

        // POST: RegistrationRecords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Created,Email,FitnessClass_Id,Name,Updated,WaitListed")] RegistrationRecord registrationRecord)
        {
            if (id != registrationRecord.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registrationRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistrationRecordExists(registrationRecord.Id))
                    {
                        return NotFound();
                    } else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["FitnessClass_Id"] = new SelectList(_context.FitnessClass, "Id", "Id", registrationRecord.FitnessClass_Id);
            return View(registrationRecord);
        }

        // GET: RegistrationRecords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registrationRecord = await _context.RegistrationRecord.SingleOrDefaultAsync(m => m.Id == id);
            if (registrationRecord == null)
            {
                return NotFound();
            }

            return View(registrationRecord);
        }

        // POST: RegistrationRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registrationRecord = await _context.RegistrationRecord.SingleOrDefaultAsync(m => m.Id == id);
            _context.RegistrationRecord.Remove(registrationRecord);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool RegistrationRecordExists(int id)
        {
            return _context.RegistrationRecord.Any(e => e.Id == id);
        }
    }
}
