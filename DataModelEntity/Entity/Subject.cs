using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataModelEntity.Entity
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }
        [Display(Name = "Fanning malakaviy kodi")]
        public string SubjectCode { get; set; }
        [Display(Name = "Fan nomi")]
        public string Name { get; set; }
        [Display(Name="Ma'ruza")]
        public int Lecture { get; set; }
        [Display(Name = "Amaliy")]
        public int Practical { get; set; }
        [Display(Name = "Labaratorya")]
        public int Laboratory { get; set; }
        [Display(Name = "Seminar")]
        public int Seminar { get; set; }
        [Display(Name = "Kurs ishi")]
        public int CourseWork { get; set; }
        [Display(Name = "Mustaqil ta'lim")]
        public int IndependentEducation { get; set; }
       
        public int OneOne { get; set; }
        public int OneTwo { get; set; }
        public int TwoOne { get; set; }
        public int TwoTwo { get; set; }
        public int ThreeOne { get; set; }
        public int ThreeTwo { get; set; }
        public int FourOne { get; set; }
        public int FourTwo { get; set; }

        public int KOneOne { get; set; }
        public int KOneTwo { get; set; }
        public int KTwoOne { get; set; }
        public int KTwoTwo { get; set; }
        public int KThreeOne { get; set; }
        public int KThreeTwo { get; set; }
        public int KFourOne { get; set; }
        public int KFourTwo { get; set; }

        public SubjectBlockType SubjectBlockType { get; set; }
        public int SubjectBlockTypeId { get; set; }
        public List<HarvestPlan> HarvestPlans { get; set; }



    }
}
