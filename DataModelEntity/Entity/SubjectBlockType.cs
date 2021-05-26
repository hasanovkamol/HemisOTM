using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataModelEntity.Entity
{
    public class SubjectBlockType
    {
        [Key]
        public int Id { get; set; }
        [Display(Name="Fon bo'limi")]
        public string Name { get; set; }
        public List<Subject> subjects { get; set; }
    }
}
