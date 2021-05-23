using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataModelEntity.Entity
{
    public class UploadFile
    {
        [Key]
        public int FileId { get; set; }
        [Display(Name ="File name")]
        public string FileName { get; set; }
        public string Url { get; set; }
    }
}
