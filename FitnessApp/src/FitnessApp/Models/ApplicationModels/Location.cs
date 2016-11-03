using FitnessApp.Core;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ApplicationModels.FitnessApp.Models
{
    public class Location : EntityBase
    {
        [Display(Name = "Room")]
        public string Name { get; set; }
        public List<FitnessClass> FitnessClasses { get; set; }
    }
}
