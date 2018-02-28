using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.Kestrel.Transport.Abstractions.Internal;
using System.Security.Cryptography;
using Newtonsoft.Json;
using System.Net;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using System.Security.Cryptography.X509Certificates;

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
				.SetBasePath(Environment.CurrentDirectory)
				.AddEnvironmentVariables()
				.AddCommandLine(args)
				.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
				.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true)
				.Build();

			var delay = Environment.GetEnvironmentVariable("DELAY_START");
			if(int.TryParse(delay, out var d))
			{
				Console.WriteLine($"Delaying start by {d} milliseconds");
				Task.Delay(d).Wait();
			}


			var host = new WebHostBuilder()
				.UseKestrel(option =>
				{
					void portOption(ListenOptions o)
					{
						if(bool.TryParse(cbuilder["UseSSL"], out var r))
						{
							if (r)
							{
								var cert = new X509Certificate2(cbuilder["SSLCert"], cbuilder["SSLPassword"]);
								o.UseHttps(cert);
							}
						}
					};

					if(ushort.TryParse(cbuilder["Port"], out var port))
					{
						option.Listen(IPAddress.Any, port, portOption);
					}
					else
					{
						option.Listen(IPAddress.Any, 80, portOption);
					}
				})
				.UseContentRoot(Directory.GetCurrentDirectory())
				.UseConfiguration(cbuilder)
				.UseIISIntegration()
				.UseStartup<Startup>()
				.Build();

			host.Run();
		}
	}
}
