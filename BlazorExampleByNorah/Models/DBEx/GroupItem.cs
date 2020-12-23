using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorExampleByNorah.Models
{
    public class GroupItem
    {
        public int Idx { get; set; }
        public string Code { get; set; }

        [Required(ErrorMessage = "The Id is required")]
        public string Id { get; set; }

        [Required(ErrorMessage = "The Desc is required")]
        public string Desc { get; set; }
        public string Site { get; set; }
        public int Downlimit { get; set; }

        [Range(0, 10000, ErrorMessage = "The field Level must be between 0 and 10000.")]
        public int Level { get; set; }
        public string Pack { get; set; }
        public DateTime Expiry { get; set; }
        public DateTime Edit { get; set; }
        public string Update { get; set; }
        public string Svctype { get; set; }
        public string Colset { get; set; }
        public string Online { get; set; }
        public string Creater { get; set; }
        public DateTime Create { get; set; }
        public string Lastmodifier { get; set; }
        public string Memo { get; set; }

    }

}
