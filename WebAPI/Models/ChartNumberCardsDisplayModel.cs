using System.Collections.Generic;

namespace WebAPI.Models
{
    public class ChartNumberCardsDisplayModel
    {
        public  List<Name> name { get; set; }
        public List<Value> value { get; set; }

    }
    public class Value
    {
        public float value { get; set; }

    }
    public class Name
    {
        public string name { get; set; }

    }
}
