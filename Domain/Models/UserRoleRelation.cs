using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
   public class UserRoleRelation
    {
        public int Id { get; set; }
        public string UserSesaFK { get; set; }
        public int RoleIdFK { get; set; }

        [ForeignKey(nameof(UserSesaFK))]
        public virtual User user { get; set; }

        [ForeignKey(nameof(RoleIdFK))]
        public virtual Role role { get; set; }

    }
}
