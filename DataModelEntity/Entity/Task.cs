using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModelEntity.Entity
{
    public class Task
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name ="Vazifa nomi")]
        public string TaskName { get; set; }
        [Display(Name = "Resoures")]
        public string FileName { get; set; }
        [Display(Name = "Vazifa turi")]
        public string TaskType { get; set; }
        [Display(Name = "Qo'yilgan vaqt")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Vaqt chegarasi")]
        public DateTime EndDate { get; set; }
        public int SubjectId { get; set; }
        public int GrupId { get; set; }
    }
}
