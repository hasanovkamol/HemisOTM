using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataModelEntity.Entity
{
    public class Grup
    {
        [Key]
        public int GrupId { get; set; }
        [Display(Name="Grup name")]
        public string Name { get; set; }
        public int StudentId { get; set; }
        public Student GetStudent { get; set; }
        public List<HarvestPlan> HarvestPlans { get; set; }

    }
}
