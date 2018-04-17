using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sannel.House.Web.Base.Models
{
	public class THPEntry : TemperatureEntry
	{
		public const string SENSORTYPE = "THP";
		public override string SensorType { get => SENSORTYPE; set { } }

		[JsonProperty(nameof(Humidity))]
		public double? Humidity { get; set; }

		[JsonProperty(nameof(Pressure))]
		public double? Pressure { get; set; }
	}
}
