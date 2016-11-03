using FitnessApp.IRepository;
using FitnessApp.Core;
using ApplicationModels.FitnessApp.Models;
using FitnessApp.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FitnessApp.Repository
{
    public class FitnessClassRepository : IFitnessClassRepository  //Repository<FitnessClass>, IFitnessClassRepository
    {
        private FitnessAppDbContext _context;
        public FitnessClassRepository(FitnessAppDbContext context) //: base(context)
        {
            _context = context;
        }

        public async Task<List<FitnessClass>> All()
        {
            return await _context.FitnessClass.Include(f => f.FitnessClassType)
                                                    .Include(t => t.Instructor)
                                                    .Include(l => l.Location).ToListAsync();
        }
    }
}
