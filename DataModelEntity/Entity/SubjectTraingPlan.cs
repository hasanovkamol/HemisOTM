using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataModelEntity.Entity
{
    public class SubjectTraingPlan
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubjectTraingPlanId { get; set; }
        public int? GetSubjectId { get; set; }
        [ForeignKey("GetSubjectId")]
        public virtual Subject GetSubject { get; set; }
        public int? GetHardvesPlanId { get; set; }
        [ForeignKey("GetHardvesPlanId")]
        public virtual HarvestPlan GetHarvestPlan { get; set; }
    }
}
