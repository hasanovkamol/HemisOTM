using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataModelEntity.Entity
{
    public class Direction
    {
        [Key]
        [Display(Name = "№")]
        public int DirectionId { get; set; }
        [Display(Name="Direction code")]
        public string Code { get; set; }
        [Display(Name = "Direction name")]
        public string Name { get; set; }
        public List<Grup> GetGrups { get; set; }
        public List<Student> Students { get; set; }
    }
}
