using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorExampleByNorah.Models
{
    public class BasicInputModel
    {
        public string inputHidden { get; set; }
        public string inputTextStr { get; set; }
        public string inputTextStr2 { get; set; }
        [Range(1, 100000, ErrorMessage = "inputTextInt invalid (1-100000).")]
        public int inputTextInt { get; set; }
        public int inputTextInt2 { get; set; }
        public DateTime inputTextDate { get; set; }
        public DateTime inputTextDate2 { get; set; }
        public string inputPassword { get; set; }
        public string textArea { get; set; }
        public string textArea2 { get; set; }
        public bool isChecked { get; set; }
        public bool isChecked2 { get; set; }
        public string checkedRadio { get; set; }
        public string selectedSelection { get; set; }
        public string selectedSelection2 { get; set; }

    }

    public class RadioModel
    {
        public string Value { get; set; }
        public string Text { get; set; }
    }

    public class SelectModel
    {
        public string Value { get; set; }
        public string Text { get; set; }        
    }

    public class ValidInputModel : BasicInputModel
    {
        public new string inputHidden { get; set; }
        [Required]
        [Phone]
        public new string inputTextStr { get; set; }
        [Required]
        [EmailAddress]
        public new string inputTextStr2 { get; set; }
        [Required]
        [Range(1, 100000, ErrorMessage = "inputTextInt invalid (1-100000).")]
        public new int inputTextInt { get; set; }
        public new int inputTextInt2 { get; set; }
        public new DateTime inputTextDate { get; set; }
        public new DateTime inputTextDate2 { get; set; }
        public new string inputPassword { get; set; }
        public new string textArea { get; set; }
        public new string textArea2 { get; set; }
        [Required]        
        public new bool isChecked { get; set; }
        public new bool isChecked2 { get; set; }
        [Required]
        public new string checkedRadio { get; set; }
        [Required]
        public new string selectedSelection { get; set; }
        public new string selectedSelection2 { get; set; }

    }
}
