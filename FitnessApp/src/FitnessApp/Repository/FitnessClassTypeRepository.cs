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
    public class FitnessClassTypeRepository : IFitnessClassTypeRepository
    {
        private FitnessAppDbContext _context;
        public FitnessClassTypeRepository(FitnessAppDbContext context) 
        {
            _context = context;
        }

        public async Task<List<FitnessClassType>> All()
        {
            return await _context.FitnessClassType.ToListAsync();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public FitnessClassType FindById(int id)
        {
            return _context.FitnessClassType.SingleOrDefault(m => m.Id == id);
        }

        public async Task Insert(FitnessClassType fitnessClassType)
        {
            if (fitnessClassType.Id > 0)
            {
                _context.Update(fitnessClassType);
            }
            else
            {
                _context.Add(fitnessClassType);
            }
            await _context.SaveChangesAsync();
        }
    }
}
