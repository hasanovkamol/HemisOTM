using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataModelEntity.Entity
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [Display(Name="Middil name")]
        public string Middilname { get; set; }
        [Display(Name="Diraction name")]
        public Direction GetDirection { get; set; }
        public int DirectionId { get; set; }
        public int Course { get; set; }

    }
}
