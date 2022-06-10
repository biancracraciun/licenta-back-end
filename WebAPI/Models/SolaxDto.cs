using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
	public class SolaxDto
	{
		public string Success { get; set; }
		public string Exception { get; set; }
		public Result result { get; set; }

	}

	public class Result
	{ 
		public string InverterSn { get; set; }
		public string Sn { get; set; }
		public float? AcPower { get; set; }
		public float? YieldToday { get; set; }
		public float? YieldTotal{ get; set; }
		public float? FeedInPower { get; set; }
		public float? FeedInEnergy { get; set; }
		public float? ConsumeEnergy { get; set; }
		public float? FeedInPowerM2 { get; set; }
		public int? InverterType { get; set; }
		public int? InverterStatus { get; set; }
		public DateTime? UploadTime { get; set; }
		public float? PowerDc1{ get; set; }
		public float? PowerDc2 { get; set; }





	}
}
