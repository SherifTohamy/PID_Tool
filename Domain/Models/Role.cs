using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models
{
    public class Role
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [Required]
        [MaxLength(10)]
        public string shortcut { get; set; }
        [Required]
        [MaxLength(200)]
        public string Priority { get; set; }

        public virtual ICollection<UserRoleRelation> RoleUserRelations { get; set; }
        public virtual ICollection<RoleSubjectRelation> RoleSubjectRelations { get; set; }


    }
}
