using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Models.ApplicationViewModels
{
    public class FitnessClassTypeView
    {
        [Display(Name = "Fitness Class Type")]
        public int Id { get; set; }

        [Display(Name = "Class Type")]
        public string Name { get; set; }

        [Display(Name = "Active")]
        public bool Status { get; set; }

    }
}
