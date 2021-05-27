using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataModelEntity.Entity
{
    public class SubjectTraingPlan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubjectTraingPlanId { get; set; }
        public int SubjectId { get; set; }
        [ForeignKey("SubjectId")]
        public Subject GetSubject { get; set; }
        public int HardvesPlanId { get; set; }
        [ForeignKey("HardvesPlanId")]
        public HarvestPlan GetHarvestPlan { get; set; }
    }
}
