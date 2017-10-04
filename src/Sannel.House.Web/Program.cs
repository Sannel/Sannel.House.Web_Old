using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using Newtonsoft.Json;

namespace Sannel.House.Web
{
	public class Program
	{
		private static void generateKeys(string fileName)
		{
			var rsa = new RSACryptoServiceProvider(2048);
			var publicKey = rsa.ExportParameters(true);
			var data = JsonConvert.SerializeObject(publicKey);
			var dir = Path.GetDirectoryName(fileName);
			if (!string.IsNullOrWhiteSpace(dir))
			{
				if (!Directory.Exists(dir))
				{
					Directory.CreateDirectory(dir);
				}
			}
			File.WriteAllText(fileName, data);
		}

		public static void Main(string[] args)
		{
			if (args.Length > 0 && string.Compare(args[0], "--generate-keys", true) == 0)
			{
				if (args.Length > 1 && !string.IsNullOrWhiteSpace(args[1]))
				{
					generateKeys(args[1]);
				}
				else
				{
					generateKeys("App_Data\\RSAKeys.json");
				}
				return;
			}

			var cbuilder = new ConfigurationBuilder()
				.AddCommandLine(args)
				.Build();


			var host = new WebHostBuilder()
				.UseKestrel()
				.UseContentRoot(Directory.GetCurrentDirectory())
				.UseConfiguration(cbuilder)
				.UseIISIntegration()
				.UseStartup<Startup>()
				.Build();

			host.Run();
		}
	}
}
