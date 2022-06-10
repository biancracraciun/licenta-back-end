using System;

namespace WebAPI.Models
{
    public class Solax
    {
		public int Id { get; set; }
		public string InverterSn { get; set; }
		public float? AcPower { get; set; }
		public float? YieldToday { get; set; }
		public float? YieldTotal { get; set; }
		public float? FeedInPower { get; set; }
		public float? FeedInEnergy { get; set; }
		public float? ConsumeEnergy { get; set; }
		public int? InverterType { get; set; }
		public int? InverterStatus { get; set; }
		public DateTime? UploadTime { get; set; }
		public float? PowerDc1 { get; set; }
		public float? PowerDc2 { get; set; }
	}
}
