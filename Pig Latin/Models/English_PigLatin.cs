using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Pig_Latin.Models
{
    public class English_PigLatin
    {
        [Display(Name = "Text in English")]
        [Required(ErrorMessage = "Please enter some text ")]
        public string English_text { get; set; }

        [Display(Name = "Text in Pig Latin")]
        public string PigLatin_text { get; set; }   
    }
}