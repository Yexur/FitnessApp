﻿using ApplicationModels.FitnessApp.Models;
using FitnessApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Logic
{
    public class FitnessClassLogic : IFitnessClassLogic
    {
        private readonly FitnessAppDbContext _context;

        public FitnessClassLogic(FitnessAppDbContext context)
        {
            _context = context;
        }

        //public FitnessClass Get(int id)
        //{
        //    return _fitnessClassRepository.FindById(id);
        //}

        public async Task<List<FitnessClassListItem>> GetList()  // add the repositoryy layer
        {
            var fitnessClasses = await _context.FitnessClass.Include(f => f.Instructor)
                                                            .Include(t => t.Location)
                                                            .Include(m => m.FitnessClassType).ToListAsync();

            if (fitnessClasses == null || !fitnessClasses.Any())
            {
                return Enumerable.Empty<FitnessClassListItem>().ToList();
            }

            return MapFitnessClassToFitnessClassListItem(fitnessClasses);
        }

        //public void Save(FitnessClass fitnessClass)
        //{
        //    _fitnessClassRepository.Insert(fitnessClass);
        //}

        //public void Delete(int id)
        //{
        //    _fitnessClassRepository.Delete(id);
        //}

        private List<FitnessClassListItem> MapFitnessClassToFitnessClassListItem(List<FitnessClass> fitnessClasses) {
            List<FitnessClassListItem> fitnessClassListItems = new List<FitnessClassListItem>();

            foreach (var item in fitnessClasses)
            {
                fitnessClassListItems.Add(new FitnessClassListItem()
                {
                    Id = item.Id,
                    Capacity = item.Capacity,
                    StartTime = item.StartTime,
                    EndTime = item.EndTime,
                    DateOfClass = item.DateOfClass,
                    Status = item.Status,
                    ClassType = item.FitnessClassType.Id.ToString(),  //needs to be a call to get the name
                    Instructor = item.Instructor.Id.ToString(), //needs to be a call to get the name
                    Location = item.Location.Id.ToString() //needs to be a call to get the name
                });
            }
            return fitnessClassListItems;
        }
    }
}
