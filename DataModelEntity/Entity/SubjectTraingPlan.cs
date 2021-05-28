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
       
        public int? HardvesPlanId { get; set; }
        [ForeignKey("HardvesPlanId")]
        public virtual HarvestPlan HarvestPlan { get; set; }

        public int? SubjectId { get; set; }
        [ForeignKey("SubjectId")]
        public virtual Subject Subject { get; set; }
    }
}
