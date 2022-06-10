using System.Collections.Generic;

namespace WebAPI.Models
{
    public class ChartDisplayModelHourly
    {
        public string name { get; set; }
        public List<Series>  series { get; set; }
    }

    public class Series
{
        public string name { get; set; }
        public float? value { get; set; }
    }



    
}
