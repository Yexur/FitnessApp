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

        //use this in the controller to filter the registration recordds returned
        //based on the username
        //noit actaullt needed here
       // var user = await _userManager.FindByNameAsync(this.User.Identity.Name);
        // GET: RegistrationRecords
        public async Task<IActionResult> Index()
        {
            var userName = User.Identity.Name; //pass this to the logic side
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
