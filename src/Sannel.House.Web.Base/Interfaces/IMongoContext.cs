using MongoDB.Driver;
using Sannel.House.Web.Base.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sannel.House.Web.Base.Interfaces
{
	public interface IMongoContext
	{
		IMongoCollection<Sannel.House.Sensor.SensorEntry> SensorEntries { get; }
	}
}
