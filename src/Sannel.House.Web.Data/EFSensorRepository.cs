using Sannel.House.Web.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sannel.House.Web.Data
{
	public class EFSensorRepository : ISensorRepository
	{
		private DataContext context;

		public EFSensorRepository(DataContext context)
		{
			this.context = context;
		}
	}
}
