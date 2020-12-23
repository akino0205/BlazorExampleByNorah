using System;

namespace BlazorExampleByNorah.Modules
{
    public class HtmlUtil
    {
        public static string DisplayDateTime(DateTime date)
        {
            return date.ToString("d");
        }
    }
}
