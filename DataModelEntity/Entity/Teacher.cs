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
        [Display(Name = "Ismi")]
        public string Name { get; set; }
        [Display(Name = "Familiya")]
        public string Surname { get; set; }
        [Display(Name = "Otasini ismi")]
        public string Middilname { get; set; }
        public string Position { get; set; }
        [Display(Name = "Ilmiy darajasi")]
        public string AcademicDegree { get; set; }
        public int DepartmentId { get; set; }
        [Display(Name= "Kafedra nomi")]
        public Department GetDepartment { get; set; }
        public List<HarvestPlan> HarvestPlans { get; set; }
        [Display(Name="Ma'sul (FIO)")]
        public string FullName { get => this.Name + " " + this.Surname; }
    }
}
