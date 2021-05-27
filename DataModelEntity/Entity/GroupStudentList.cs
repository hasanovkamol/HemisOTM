using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataModelEntity.Entity
{
    public class GroupStudentList
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GroupStudentId { get; set; }
        public int? StudentId { get; set; }
        [ForeignKey("StudentId")]
        public virtual Student GetStudent { get; set; }
        public int? GrupId { get; set; }
        [ForeignKey("GrupId")]
        public virtual Grup GetGrup { get; set; }
    }
}
