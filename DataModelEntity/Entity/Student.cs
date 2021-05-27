using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataModelEntity.Entity
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Display(Name = "Ism")]
        public string Name { get; set; }
        [Display(Name = "Familya")]
        public string Surname { get; set; }
        [Display(Name= "Otasini ismi")]
        public string Middilname { get; set; }
        [Display(Name="Yo'nalish")]
        public Direction GetDirection { get; set; }
        public int DirectionId { get; set; }
        [Display(Name = "Kurs")]
        public int Course { get; set; }
        [Display(Name = "Birlashgan gruh nomi")]
        public string GrupName { get; set; }
       

    }
}
