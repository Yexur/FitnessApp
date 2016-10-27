using FitnessApp.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace ApplicationModels.FitnessApp.Models
{
    public class RegistrationRecord : EntityBase
    {
        [DataMember]
        [Required]
        public string Name { get; set; }

        [DataMember]
        [Required]
        public string Email { get; set; }

        [DataMember]
        [Required]
        public bool WaitListed { get; set; }

        [ForeignKey("FitnessClass_Id")]
        public virtual FitnessClass FitnessClass { get; set; }
    }
}
