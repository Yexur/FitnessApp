using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Models.ApplicationViewModels
{
//this is not correct this is the view of the classes you have registered for the validation messages here are incorrect
    public class RegistrationRecordView
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; } //these will be the same field as the username so we do not need them on the view

        [Required(ErrorMessage = "Please enter your email address")]
        public string Email { get; set; }

        [Display(Name = "On Wait List")]
        public bool WaitListed { get; set; }

        public int FitnessClass_Id { get; set; }

        [Display(Name = "Fitness Classes")]
        public FitnessClassView FitnessClass { get; set; }
    }
}
