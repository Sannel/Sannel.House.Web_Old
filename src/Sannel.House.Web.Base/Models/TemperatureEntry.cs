/* Copyright 2017 Sannel Software, L.L.C.

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

	   http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.*/

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sannel.House.Web.Base.Models
{
	[Generation(DontGenerateMethods = new GenerationAttribute.ApiCalls[]
	{
		GenerationAttribute.ApiCalls.Delete,
		GenerationAttribute.ApiCalls.Put
	})]
	public class TemperatureEntry
	{
		public TemperatureEntry()
		{
		}
		[Key]
		[JsonProperty(nameof(Id))]
		public Guid Id { get; set; }

		[JsonProperty(nameof(DeviceId))]
		[Generation(GreaterThenZero = true)]
		public int DeviceId { get; set; }

		[JsonIgnore]
		[Generation(Ignore = true)]
		public Device Device { get; set; }

		[NotMapped]
		public long? DeviceMacAddress {get;set;}

		[JsonProperty(nameof(TemperatureCelsius))]
		public double TemperatureCelsius { get; set; }

		[JsonProperty(nameof(Humidity))]
		public double? Humidity { get; set; }

		[JsonProperty(nameof(Pressure))]
		public double? Pressure { get; set; }

		[JsonProperty(nameof(DateCreated))]
		public DateTime DateCreated { get; set; }
	}
}
