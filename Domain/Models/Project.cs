using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PIDDb.Models
{
    public class Project
    {

        [Required]
        [Key]
        [Column(Order = 1)]
        public string Id { get; set; }
        [Required]
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public float BudgetHours { get; set; }
        public string Comments { get; set; }
        public string ClosedBy { get; set; }
        public DateTime timeStamp
        {
            get
            {
                return timeStamp;
            }
            set
            {
                timeStamp = DateTime.Now;
            }
        }
        public virtual ICollection<ProjectUserRelation> ProjectUserRelations { get; set; }

    }
}
