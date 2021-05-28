using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataModelEntity.Entity
{
    public class HarvestPlan
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HarvestPlanId { get; set; }
        [Display(Name="O'quv reja nomi")]
        public string Name { get; set; }
        public int DepatmentId { get; set; }
        public Department GetDepartment { get; set; }
        public int TeacherId { get; set; }
        public Teacher GetTeacher { get; set; }
        public int GrupId { get; set; }
        public Grup Grups { get; set; }
      
        public ICollection<SubjectTraingPlan> subjectTraingPlans { get; set; }
    }
}
