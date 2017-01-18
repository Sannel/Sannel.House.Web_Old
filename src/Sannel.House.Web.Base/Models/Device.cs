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

#if THERMOSTAT
namespace Sannel.House.Thermostat.Base.Models
#else
namespace Sannel.House.Web.Base.Models
#endif
{
	/// <summary>
	/// Represents a device using the platform
	/// </summary>
	public class Device
	{
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>
		/// The identifier.
		/// </value>
#if !THERMOSTAT
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
#endif
		[Key]
		[JsonProperty("Id")]
		public int Id { get; set; }

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
		[MaxLength(256)]
		[Required]
		[JsonProperty("Name")]
		[Generation(CheckForEmptyString = true)]
		public String Name { get; set; }

		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		/// <value>
		/// The description.
		/// </value>
		[MaxLength(2000)]
		[Required]
		[JsonProperty("Description")]
		[Generation(IsRequired = true)]
		public String Description { get; set; }


		/// <summary>
		/// Gets or sets the display order.
		/// </summary>
		/// <value>
		/// The display order.
		/// </value>
		[JsonProperty("DisplayOrder")]
		[Generation(ShouldBeCount = true)]
		public int DisplayOrder { get; set; }

		/// <summary>
		/// Gets or sets the date created.
		/// </summary>
		/// <value>
		/// The date created.
		/// </value>
		[JsonProperty("DateCreated")]
		[Generation(IsNow = true, CantUpdate = true)]
		public DateTimeOffset DateCreated { get; set; }

		/// <summary>
		/// Gets or sets if this device is readonly
		/// </summary>
		[JsonProperty("IsReadOnly")]
		[Generation(CantUpdate = true)]
		public bool IsReadOnly { get; set; }
	}
}
