using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Domain.Models
{
    public class Subject
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        public string Actions { get; set; }

        public virtual ICollection<RoleSubjectRelation> SubjectRoleRelations { get; set; }

        //string json = JsonConverter.SerializeObject();

    }
}
