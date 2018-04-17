using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sannel.House.Web.Base.Models
{
	public class SensorEntry
	{
		[BsonId]
		[JsonProperty(nameof(Id))]
		public Guid Id { get; set; }

		[Required]
		[JsonProperty(nameof(SensorType))]
		public virtual string SensorType { get; set; }

		[JsonProperty(nameof(DeviceId))]
		public int DeviceId { get; set; }

		[NotMapped]
		[JsonProperty(nameof(DeviceMacAddress))]
		public long? DeviceMacAddress
		{
			get;
			set;
		}

		[JsonProperty(nameof(DateCreated))]
		public DateTime DateCreated { get; set; }

		[JsonIgnore]
		public IDictionary<string, object> ExtraElements { get; set; }

		public IDictionary<string, double> Values { get; set; }
	}
}
