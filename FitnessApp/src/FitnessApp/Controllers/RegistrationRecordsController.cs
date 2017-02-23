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
using FitnessApp.Logic;

namespace FitnessApp.Controllers
{
    [Authorize]
    public class RegistrationRecordsController : Controller
    {
        private readonly IRegistrationRecordLogic _registrationRecordLogic;
        private readonly IFitnessClassLogic _fitnessClassLogic;

        public RegistrationRecordsController(IRegistrationRecordLogic registrationRecordLogic)
        {
            _registrationRecordLogic = registrationRecordLogic;
        }

        // GET: RegistrationRecords
        public async Task<IActionResult> RegistrationIndex()
        {
            return View(await _registrationRecordLogic.FindByUserName(User.Identity.Name));
        }

        // GET: RegistrationRecords/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var registrationRecord = await _context.RegistrationRecord.SingleOrDefaultAsync(m => m.Id == id);
        //    if (registrationRecord == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(registrationRecord);
        //}

        //// POST: RegistrationRecords/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var registrationRecord = await _context.RegistrationRecord.SingleOrDefaultAsync(m => m.Id == id);
        //    _context.RegistrationRecord.Remove(registrationRecord);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}
    }
}
