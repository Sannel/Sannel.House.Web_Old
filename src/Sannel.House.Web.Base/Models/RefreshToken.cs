using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sannel.House.Web.Base.Models
{
    public class RefreshToken
    {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public Guid RefreshTokenId
		{
			get;
			set;
		}

		public DateTime Expires { get; set; }

		public String UserId { get; set; }
	}
}
