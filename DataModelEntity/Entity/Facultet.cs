using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataModelEntity.Entity
{
    public class Facultet
    {
        [Key]
        [Display(Name = "№")]
        public int FacultetID { get; set; }
        [Display(Name = "Fakultet nomi")]
        public string Name { get; set; }
        public List<Department> GetDepartments { get; set; }
    }
}
