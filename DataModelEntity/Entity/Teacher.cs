using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataModelEntity.Entity
{
    public class Teacher
    {
        [Key]
        [Display(Name = "№")]
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [Display(Name = "Middil name")]
        public string Middilname { get; set; }
        public string Position { get; set; }
        [Display(Name = "Academic degree")]
        public string AcademicDegree { get; set; }
        public int DepartmentId { get; set; }
        [Display(Name= "Department name")]
        public Department GetDepartment { get; set; }
        public List<HarvestPlan> HarvestPlans { get; set; }
    }
}
