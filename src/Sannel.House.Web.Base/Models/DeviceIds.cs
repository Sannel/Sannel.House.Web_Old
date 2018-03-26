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
	public class AlternateDeviceId
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
		/// Gets or sets the date created.
		/// </summary>
		/// <value>
		/// The date created.
		/// </value>
		[JsonProperty("DateCreated")]
		[Generation(IsNow = true, CantUpdate = true)]
		public DateTime DateCreated { get; set; }

		/// <summary>
		/// Gets or sets the UUID for the alternate id.
		/// </summary>
		/// <value>
		/// The UUID.
		/// </value>
		public Guid? Uuid { get; set; }
	}
}
