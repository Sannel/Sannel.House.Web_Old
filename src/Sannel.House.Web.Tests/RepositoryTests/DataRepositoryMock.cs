using Sannel.House.Web.Interfaces;
using Sannel.House.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Web.Tests.RepositoryTests
{
	public class DataRepositoryMock : IDataRepository
	{
		public Func<int, Task<Device>> GetDeviceFunc { get; set; }

		public Task<Device> GetDeviceAsync(int deviceId)
		{
			return GetDeviceFunc?.Invoke(deviceId);
		}
	}
}
