using FitnessApp.Core;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ApplicationModels.FitnessApp.Models
{
    public class Instructor : EntityBase
    {
        [Display(Name = "Instructor")]
        public string Name { get; set; }
        public List<FitnessClass> FitnessClasses { get; set; }
    }
}
