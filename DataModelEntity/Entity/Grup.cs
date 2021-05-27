using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataModelEntity.Entity
{
    public class Grup
    {
        [Key]
        public int GrupId { get; set; }
        [Display(Name="Grup name")]
        public string Name { get; set; }
        [ForeignKey("DirectId")]
        public int DirectId { get; set; }
        public Direction DirectionList { get; set; }
        public List<HarvestPlan> HarvestPlans { get; set; }

    }
}
