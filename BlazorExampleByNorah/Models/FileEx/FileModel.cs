using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorExampleByNorah.Models
{
    public class ImageFileModel
    {
        public string Name { get; set; }
        public long Size { get; set; }
        public DateTimeOffset LastModified { get; set; }
        public string ContentType { get; set; }
        public string ImageDataUrl { get; set; }
    }
}
