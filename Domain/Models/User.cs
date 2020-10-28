using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models
{
   public class User
    {
        
        [Required]
        [MaxLength(10)]
        [Key]
        public string SESANum { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }


        public virtual ICollection<UserRoleRelation> UserRoleRelations { get; set; }







    }
}
