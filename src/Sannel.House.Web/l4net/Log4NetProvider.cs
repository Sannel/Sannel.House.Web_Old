/* This class is based of the class at https://dotnetthoughts.net/how-to-use-log4net-with-aspnetcore-for-logging/ */
using log4net.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace Sannel.House.Web.l4net
{
	public class Log4NetProvider : ILoggerProvider
	{
		private readonly string _log4NetConfigFile;
		private readonly ConcurrentDictionary<string, Log4NetLogger> _loggers =
			new ConcurrentDictionary<string, Log4NetLogger>();

		public Log4NetProvider(string log4NetConfigFile) 
			=> _log4NetConfigFile = log4NetConfigFile;

		public Microsoft.Extensions.Logging.ILogger CreateLogger(string categoryName) 
			=> _loggers.GetOrAdd(categoryName, createLoggerImplementation);

		public void Dispose()
		{
			_loggers.Clear();
		}
		private Log4NetLogger createLoggerImplementation(string name) 
			=> new Log4NetLogger(name, parselog4NetConfigFile(_log4NetConfigFile));

		private static XmlElement parselog4NetConfigFile(string filename)
		{
			var log4netConfig = new XmlDocument();
			log4netConfig.Load(File.OpenRead(filename));
			return log4netConfig["log4net"];
		}
	}
}
