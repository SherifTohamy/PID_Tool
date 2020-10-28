using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
    public class RoleSubjectRelation
    {
        public int Id { get; set; }
        public int RoleIdFK { get; set; }  
        public int SubjectIdFK { get; set; }
        [ForeignKey(nameof(RoleIdFK))]
        public virtual Role role { get; set; }

        [ForeignKey(nameof(SubjectIdFK))]
        public virtual Subject subject { get; set; }
    }
}
