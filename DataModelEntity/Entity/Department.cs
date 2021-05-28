using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataModelEntity.Entity
{
    public class Department
    {
        [Key]
        [Display(Name = "№")]
        public int DepartmentId { get; set; }
        [Display(Name = "Kafedra nomi")]
        public string Name { get; set; }
        public int FacultetId { get; set; }
        public List<HarvestPlan> GetHarvestPlans { get; set; }
        public Facultet GetFacultet { get; set; }
      
    }
}
