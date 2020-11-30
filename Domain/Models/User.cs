using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
   public class User
    {
        
        [Required]
        [MaxLength(10)]
        [Key]
        [Column(Order = 1)]
        public string SESANum { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [Key]
        [DataType(DataType.EmailAddress)]
        [Column(Order = 2)]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsEnabled { get; set; }
        public virtual ICollection<UserRoleRelation> UserRoleRelations { get; set; }

        public virtual ICollection<ProjectUserRelation> ProjectUserRelations { get; set; }







    }
}
