using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorExampleByNorah.Models
{
    public class WeatherInfoParam
    {
        public string ServiceKey { get; set; }
        public int NumOfRows { get; set; }
        public int PageNo { get; set; }
        public string DataType { get; set; }
        public int StnId { get; set; }
        public DateTime FromTmFc { get; set; }
        public DateTime ToTmFc { get; set; }
    }

    public class WeatherInfoResult
    {
        public string Title { get; set; }
        public string StnId { get; set; }
        public int TmSeq { get; set; }
        public object TmFc { get; set; }
    }
}
