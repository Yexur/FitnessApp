using FitnessApp.Core;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ApplicationModels.FitnessApp.Models
{
    public class FitnessClassType : EntityBase
    {
        [Display(Name ="Type of Class")]
        public string Name { get; set; }

        public bool Status { get; set; }

        public List<FitnessClass> FitnessClasses { get; set; }
    }
}
