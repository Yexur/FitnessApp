using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace FitnessApp.Core
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }

        [DataMember]
        public DateTime Created { get; set; }

        [DataMember]
        public DateTime Updated { get; set; }
    }
}
