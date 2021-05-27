using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataModelEntity.Entity
{
    public class HarvestPlan
    {
        [Key]
        public int HarvestPlanId { get; set; }
        public string Name { get; set; }
        [ForeignKey("DepatmentId")]
        public int DepatmentId { get; set; }
        public Department GetDepartment { get; set; }
        public int TeacherId { get; set; }
        public Teacher GetTeacher { get; set; }
        public ICollection<SubjectTraingPlan> subjectTraingPlans { get; set; }
        public int GrupId { get; set; }
        public Grup Grups { get; set; }
      
    }
}
