using Sannel.House.Web.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Web.Interfaces
{
	public interface IDataRepository
	{
		Task<Device> GetDeviceAsync(int deviceId);
	}
}
