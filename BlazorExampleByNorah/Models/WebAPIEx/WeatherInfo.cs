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
        public string ResultCode { get; set; }
        public string ResultMsg { get; set; }
        public int NumOfRows { get; set; }
        public int PageNo { get; set; }
        public int TotalCount { get; set; }
        public string DataType { get; set; }
        public string Title { get; set; }
        public string StnId { get; set; }
        public DateTime TmSeq { get; set; }
        public DateTime TmFc { get; set; }
    }
}
