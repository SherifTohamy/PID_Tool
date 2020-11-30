using PIDDb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
  public class ProjectUserRelation
    {
        public int Id { get; set; }
        public string UserSesaFK { get; set; }
        public string ProjectIdFK { get; set; }

        [ForeignKey(nameof(UserSesaFK))]
        public virtual User user { get; set; }

        [ForeignKey(nameof(ProjectIdFK))]
        public virtual Project project { get; set; }

    }
}
