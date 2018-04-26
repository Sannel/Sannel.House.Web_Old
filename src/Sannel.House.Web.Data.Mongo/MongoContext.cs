using MongoDB.Driver;
using Sannel.House.Web.Base.Interfaces;
using Sannel.House.Web.Base.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sannel.House.Web.Data.Mongo
{
	public class MongoContext : IMongoContext, IDisposable
	{
		private MongoClient client;
		private IMongoDatabase database;

		public MongoContext(string connectionString)
		{
			var url = MongoUrl.Create(connectionString);
			client = new MongoClient(url);
			database = client.GetDatabase(url.DatabaseName ?? "sannel_house");
		}

		public IMongoCollection<Sannel.House.Sensor.SensorEntry> SensorEntries 
			=> database.GetCollection<Sannel.House.Sensor.SensorEntry>(nameof(Sannel.House.Sensor.SensorEntry));

		public void Dispose()
		{
			database = null;
			client = null;
		}
	}
}
