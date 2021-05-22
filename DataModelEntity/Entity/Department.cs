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
        public string Name { get; set; }
        public int FacultetId { get; set; }
        public Facultet GetFacultet { get; set; }
      
    }
}
