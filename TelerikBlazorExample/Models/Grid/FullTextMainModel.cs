using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelerikBlazorExample.Models
{
    public class FullTextMainModel
    {
        public Fulltext_main fulltext_main { get; set;}

        public class Fulltext_main
        {
            public int idx { get; set; }
            public string patentNumber { get; set; }
            public DateTime applicationDate { get; set; }
            public string collection { get; set; }
            public string title { get; set; }
        }
    }
}
