using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TemperatureConverter.TemperatureService;

namespace TemperatureConverter.Web.Models
{
	/// <summary>
	/// The view model that holds the data for our page.
	/// </summary>
	public class TemperatureViewModel
	{
		public List<SelectListItem> Types { get; set; }

		public int SelectedTo { get; set; }
		public int SelectedFrom { get; set; }

		public double Amount { get; set; }
		public double Result {	get; set; }

		public TemperatureViewModel()
		{
			Types = new List<SelectListItem>()
			{
				new SelectListItem() { Value = ((int) TemperatureUnit.degreeCelsius).ToString(), Text = "Celsius" },
				new SelectListItem() { Value = ((int) TemperatureUnit.degreeFahrenheit).ToString(), Text = "Fahrenheit" },
				new SelectListItem() { Value = ((int) TemperatureUnit.degreeRankine).ToString(), Text = "Rankine" },
				new SelectListItem() { Value = ((int) TemperatureUnit.degreeReaumur).ToString(), Text = "Reaumur" },
				new SelectListItem() { Value = ((int) TemperatureUnit.kelvin).ToString(), Text = "Kelvin" },
			};
		}
	}
}