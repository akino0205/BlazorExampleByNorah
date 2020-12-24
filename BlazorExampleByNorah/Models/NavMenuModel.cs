using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorExampleByNorah.Models
{
    public class NavMenuModel
    {
        public string text { get; set; }
        public string href { get; set; }

        public bool hasSubMenu { get; set; }
        public List<NavSubMenu> subMenu { get; set; }
}
    public class NavSubMenu
    {
        public string text { get; set; }
        public string href { get; set; }
    }
}
