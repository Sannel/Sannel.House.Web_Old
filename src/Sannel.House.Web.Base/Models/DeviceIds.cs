using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sannel.House.Web.Base.Models
{
	[Generation(DontGenerateMethods = new GenerationAttribute.ApiCalls[]
	{
		GenerationAttribute.ApiCalls.Delete,
		GenerationAttribute.ApiCalls.Put
	}, GetIncludes = new string[] { nameof(TemperatureEntry.Device) })]
	public class DeviceIds
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		[JsonProperty(nameof(Id))]
		public int Id { get; set; }

		[JsonProperty(nameof(DeviceId))]
		public int DeviceId { get; set; }

		[JsonIgnore]
		[Generation(Ignore = true)]
		public Device Device { get; set; }

		/// <summary>
		/// Gets or sets the Id of the network adapter to use instead of the mac address
		/// </summary>
		/// <value>
		/// The unique identifier.
		/// </value>
		public Guid? NetworkAdapterGuidId { get; set; }
	}
}
