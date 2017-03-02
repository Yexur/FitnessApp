using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Models.ApplicationViewModels
{
    public class InstructorView
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please choose an Instructor")]
        [Display(Name = "Instructor")]
        public string Name { get; set; }

        [Display(Name = "Active")]
        public bool Status { get; set; }

    }
}
