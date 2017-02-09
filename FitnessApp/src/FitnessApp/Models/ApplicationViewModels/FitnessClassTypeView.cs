using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Models.ApplicationViewModels
{
    public class FitnessClassTypeView
    {
        [Display(Name = "Fitness Class Type")]
        [Required(ErrorMessage = "BAHHAAHHAA")]
        public int Id { get; set; }

        [Display(Name = "help I needs some help")]
        public string Name { get; set; }

        [Display(Name = "Active")]
        public bool Status { get; set; }

    }
}
