using System.Collections.Generic;

namespace MvvmExample.Models
{
	internal class CountryInfo : PlaceInfo
	{
		public IEnumerable<ProvinceInfo> ProvinceCounts { get; set; }
	}
}