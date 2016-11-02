using FitnessApp.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace ApplicationModels.FitnessApp.Models
{
    public class RegistrationRecord : EntityBase
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public bool WaitListed { get; set; }


        public int FitnessClass_Id { get; set; }
        public FitnessClass FitnessClass { get; set; }
    }
}
