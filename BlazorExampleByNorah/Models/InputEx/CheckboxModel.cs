using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorExampleByNorah.Models
{
    public class CheckboxModel
    {
        public string Value { get; set; }
        public string Text { get; set; }
        public bool isChecked { get; set; }
        public bool isDisable { get; set; }
        public string checkboxStyle { get; set; }
    }
}
