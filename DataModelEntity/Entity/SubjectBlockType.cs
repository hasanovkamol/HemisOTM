using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataModelEntity.Entity
{
    public class SubjectBlockType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name="Fon bo'limi")]
        public string Name { get; set; }
        public List<Subject> subjects { get; set; }
    }
}
