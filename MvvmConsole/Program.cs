using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MvvmConsole
{
	class Program
	{
		private const string DataUrl = @"https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/csse_covid_19_time_series/time_series_covid19_confirmed_global.csv";

		private static async Task<Stream> GetDataStream()
		{

			var client = new HttpClient();
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
			var result =await client.GetAsync(DataUrl, HttpCompletionOption.ResponseHeadersRead);
			return await result.Content.ReadAsStreamAsync();
		}

		private static  IEnumerable<string> GetDataLines()
		{
			using var data_stream = GetDataStream().Result;
			using var data_reader =  new StreamReader(data_stream);

			while (!data_reader.EndOfStream)
			{
				var line =  data_reader.ReadLine();
				if (string.IsNullOrWhiteSpace(line)) continue;
				yield return line;

			}
		}

		private static DateTime[] getDateTimes() => GetDataLines()
			.First()
			.Split(',')
			.Skip(4)
			.Select(s => DateTime.Parse(s, CultureInfo.InvariantCulture))
			.ToArray();



		static void Main(string[] args)
		{
			//WebClient client = new WebClient();
			//var client = new HttpClient();
			//ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
			//var result = client.GetAsync(DataUrl).Result;
			//var csv = result.Content.ReadAsStringAsync().Result;

			var dates = getDateTimes();

				Console.WriteLine(string.Join("\r\n", dates));
			
			Console.ReadLine();
		}


	}
}
