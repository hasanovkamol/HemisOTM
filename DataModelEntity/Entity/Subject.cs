using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataModelEntity.Entity
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }
        [Display(Name = "Fanning malakaviy kodi")]
        public int SubjectCode { get; set; }
        public string Name { get; set; }
        [Display(Name="Ma'ruza")]
        public string Lecture { get; set; }
        [Display(Name = "Amaliy")]
        public string Practical { get; set; }
        [Display(Name = "Labaratorya")]
        public string Laboratory { get; set; }
        [Display(Name = "Seminar")]
        public string Seminar { get; set; }
        [Display(Name = "Kurs ishi")]
        public string CourseWork { get; set; }
        [Display(Name = "Mustaqil ta'lim")]
        public string IndependentEducation { get; set; }
        [Display(Name = "Kredit miqdori")]
        public int AmountofCredit { get; set; }
        public List<HarvestPlan> HarvestPlans { get; set; }



    }
}
