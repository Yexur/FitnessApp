using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Models.ApplicationViewModels
{
    public class LocationView
    {
        [Display(Name = "Location")]
        public int Id { get; set; }

        [Display(Name = "Location")]
        public string Name { get; set; }
    }
}
