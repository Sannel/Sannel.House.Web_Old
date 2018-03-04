/* This class is based of the class at https://dotnetthoughts.net/how-to-use-log4net-with-aspnetcore-for-logging/ */
using Microsoft.Extensions.Logging;
using Sannel.House.Web.l4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sannel.House.Web.Extensions
{
	public static class Log4netExtensions
	{
		public static ILoggerFactory AddLog4Net(this ILoggerFactory factory, string log4NetConfigFile)
		{
			factory.AddProvider(new Log4NetProvider(log4NetConfigFile));
			return factory;
		}

		public static ILoggerFactory AddLog4Net(this ILoggerFactory factory)
		{
			factory.AddProvider(new Log4NetProvider("log4net.config"));
			return factory;
		}
	}
}
