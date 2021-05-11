using System;
using System.Net;
using System.Net.Http;

namespace MvvmConsole
{
	class Program
	{
		private const string DataUrl = @"https://github.com/CSSEGISandData/COVID-19/blob/master/csse_covid_19_data/csse_covid_19_time_series/time_series_covid19_confirmed_global.csv";
		static void Main(string[] args)
		{
			//WebClient client = new WebClient();
			var client = new HttpClient();
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
			var result = client.GetAsync(DataUrl).Result;
			var csv = result.Content.ReadAsStringAsync().Result;
			Console.ReadLine();
		}
	}
}
