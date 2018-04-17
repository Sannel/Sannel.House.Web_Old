using MongoDB.Driver;
using Sannel.House.Web.Base.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sannel.House.Web.Data.Mongo
{
	public class MongoContext : IDisposable
	{
		private MongoClient client;
		private IMongoDatabase database;

		public MongoContext(string connectionString)
		{
			var url = MongoUrl.Create(connectionString);
			client = new MongoClient(url);
			database = client.GetDatabase(url.DatabaseName ?? "sannel_house");
		}

		public IMongoCollection<SensorEntry> SensorEntries 
			=> database.GetCollection<SensorEntry>(nameof(SensorEntry));

		public void Dispose()
		{
			database = null;
			client = null;
		}
	}
}
