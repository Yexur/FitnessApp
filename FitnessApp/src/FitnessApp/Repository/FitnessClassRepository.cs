using FitnessApp.IRepository;
using ApplicationModels.FitnessApp.Models;
using FitnessApp.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FitnessApp.Repository
{
    public class FitnessClassRepository : IFitnessClassRepository
    {
        private FitnessAppDbContext _context;
        private IRegistrationRecordRepository _registrationRecordRepository;

        public FitnessClassRepository(
            FitnessAppDbContext context,
            IRegistrationRecordRepository registrationRecordRepository)
        {
            _context = context;
            _registrationRecordRepository = registrationRecordRepository;
        }

        public async Task<List<FitnessClass>> All()
        {
            return await _context.FitnessClass
                .Include(f => f.FitnessClassType)
                .Include(t => t.Instructor)
                .Include(l => l.Location).ToListAsync();
        }

        public async Task<List<FitnessClass>> AllAvailable(string userName)
        {
            IEnumerable<int> fitnessClassIds = Enumerable.Empty<int>();
            var registrationRecords = _registrationRecordRepository.FindByUserName(userName);

            if (registrationRecords != null && registrationRecords.Any())
            {
                fitnessClassIds = registrationRecords.Select(reg => reg.FitnessClass_Id);
            }

            return await _context.FitnessClass
                .Where(r => r.RemainingCapacity > 0 &&
                    r.Status == true
                    && !fitnessClassIds.Contains(r.Id)
                )
                .Include(f => f.FitnessClassType)
                .Include(t => t.Instructor)
                .Include(l => l.Location).ToListAsync();
        }

        public void Delete(int id)
        {
            var fitnessClass = FindById(id);
            _context.Remove(fitnessClass);
            _context.SaveChanges();
        }

        public FitnessClass FindById(int id)
        {
            return _context.FitnessClass
                .Include(f => f.FitnessClassType)
                .Include(t => t.Instructor)
                .Include(l => l.Location)
                .SingleOrDefault(m => m.Id == id);
        }

        public async Task Insert(FitnessClass fitnessClass)
        {
            if (fitnessClass.Id > 0)
            {
                fitnessClass.Updated = DateTime.Now;
                _context.Update(fitnessClass);
            } else
            {
                fitnessClass.Created = DateTime.Now;
                fitnessClass.Updated = DateTime.Now;
                fitnessClass.RemainingCapacity = fitnessClass.Capacity;
                _context.Add(fitnessClass);
            }
            await _context.SaveChangesAsync();
        }

        public bool FitnessClassExists(int id)
        {
            return _context.FitnessClass.Any(e => e.Id == id);
        }

        public bool UpdateCapacity(int id)
        {
            var fitnessClass = FindById(id);
            if (fitnessClass != null && fitnessClass.RemainingCapacity > 0)
            {
                fitnessClass.RemainingCapacity--;
                _context.Update(fitnessClass);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
