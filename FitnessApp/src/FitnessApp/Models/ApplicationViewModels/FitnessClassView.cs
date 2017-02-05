using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Models.ApplicationViewModels
{
    public class FitnessClassView
    {
        public int Id { get; set; }

        [Display(Name = "Start Time")]
        public string StartTime { get; set; }

        [Display(Name = "End Time")]
        public string EndTime { get; set; }

        [Display(Name = "Class Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime DateOfClass { get; set; }

        [Display(Name = "Active")]
        public bool Status { get; set; }

        [Display(Name = "Capacity")]
        public int Capacity { get; set; }

        [Display(Name = "Class Type")]
        public FitnessClassTypeView FitnessClassType { get; set; }

        public ICollection<SelectListItem> FitnessClassTypes { get; set; }

        [Display(Name = "Instructor")]
        public InstructorView Instructor { get; set; }

        public ICollection<SelectListItem> Instructors { get; set; }

        [Display(Name = "Room")]
        public LocationView Location { get; set; }

        public ICollection<SelectListItem> Locations { get; set; }
    }
}
