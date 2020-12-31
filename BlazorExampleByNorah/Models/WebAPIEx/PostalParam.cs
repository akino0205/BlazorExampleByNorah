using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorExampleByNorah.Models
{
    public class PostalParam
    {
        public string searchWord { get; set; }
        public int countPerPage { get; set; }
        public int currentPage { get; set; }
    }
}
