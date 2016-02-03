using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemperatureConverter.TemperatureService;

namespace TemperatureConverter
{
	/// <summary>
	/// A simple implementation of the Soap Client
	/// </summary>
    public class TemperatureConverter
    {
		ConvertTemperatureSoapClient client;

		public TemperatureConverter()
		{
			client = new ConvertTemperatureSoapClient();
		}

		public double Convert(double temp, TemperatureUnit from, TemperatureUnit to)
		{
			double result = client.ConvertTemp(temp, from, to);

			return result;
		}

		public async Task<double> ConvertAsync(double temp, TemperatureUnit from, TemperatureUnit to)
		{
			var result = await client.ConvertTempAsync(temp, from, to);

			return result;
		}
	}
}
