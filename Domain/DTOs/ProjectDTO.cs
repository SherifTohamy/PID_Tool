using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTOs
{
   public class ProjectDTO
    {
        public string Id { get; set; }
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public float BudgetHours { get; set; }
        public string Comments { get; set; }
        public string ClosedBy { get; set; }
    }
}
