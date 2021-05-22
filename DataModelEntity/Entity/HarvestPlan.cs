using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataModelEntity.Entity
{
    public class HarvestPlan
    {
        [Key]
        public int HarvestPlanId { get; set; }
        public string Name { get; set; }
        public string Depatment { get; set; }
        public int TeacherId { get; set; }
        public Teacher GetTeacher { get; set; }
        public int SubjectId { get; set; }
        public Subject GetSubject { get; set; }
        public int GrupId { get; set; }
        public Grup Grups { get; set; }
        public int BlockTypeId { get; set; }
        public SubjectBlockType SubjectBlockType { get; set; }
    }
}
