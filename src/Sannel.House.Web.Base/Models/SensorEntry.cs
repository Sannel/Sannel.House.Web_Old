using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sannel.House.Web.Base.Models
{
	[Generation(DontGenerateMethods = new GenerationAttribute.ApiCalls[]
	{
		GenerationAttribute.ApiCalls.Delete,
		GenerationAttribute.ApiCalls.Put
	})]
	public class SensorEntry
	{
		[Key]
		[JsonProperty(nameof(Id))]
		public Guid Id { get; set; }

		[Required]
		public Sannel.House.Sensor.SensorTypes SensorType { get; set; }

		[JsonProperty(nameof(DeviceId))]
		[Generation(GreaterThenZero = true)]
		public int DeviceId { get; set; }

		[JsonIgnore]
		[Generation(Ignore = true)]
		public Device Device { get; set; }

		[JsonProperty(nameof(Value))]
		public double Value { get; set; }
		[JsonProperty(nameof(Value2))]
		public double? Value2 { get; set; }
		[JsonProperty(nameof(Value3))]
		public double? Value3 { get; set; }
		[JsonProperty(nameof(Value4))]
		public double? Value4 { get; set; }
		[JsonProperty(nameof(Value5))]
		public double? Value5 { get; set; }
		[JsonProperty(nameof(Value6))]
		public double? Value6 { get; set; }
		[JsonProperty(nameof(Value7))]
		public double? Value7 { get; set; }
		[JsonProperty(nameof(Value8))]
		public double? Value8 { get; set; }
		[JsonProperty(nameof(Value9))]
		public double? Value9 { get; set; }

		[JsonProperty(nameof(DateCreated))]
		public DateTime DateCreated { get; set; }
	}
}
