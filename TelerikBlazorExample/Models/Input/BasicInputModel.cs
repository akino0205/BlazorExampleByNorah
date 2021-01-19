using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TelerikBlazorExample.Models
{
    public class BasicInputModel
    {
        public string inputTextStr { get; set; }
        public string inputPassword { get; set; }
        [Range(1, 100000, ErrorMessage = "inputTextInt invalid (1-100000).")]
        public int inputTextInt { get; set; }
        public DateTime inputTextDate { get; set; }
        public DateTime inputTextDate2 { get; set; }
        public DateTime inputTextDateRangeStart { get; set; }
        public DateTime inputTextDateRangeEnd { get; set; }
        public DateTime inputTextDateTime { get; set; }
        public string textArea { get; set; }
        public bool isChecked { get; set; }
        public string checkedRadio { get; set; }
        public string selectedSelection { get; set; }

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
}
