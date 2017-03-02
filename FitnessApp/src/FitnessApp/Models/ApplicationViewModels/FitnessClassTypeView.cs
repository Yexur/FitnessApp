using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Models.ApplicationViewModels
{
    public class FitnessClassTypeView
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please choose a Fitness Class")]
        [Display(Name = "Fitness Class")]
        public string Name { get; set; }

        [Display(Name = "Active")]
        public bool Status { get; set; }

    }
}
