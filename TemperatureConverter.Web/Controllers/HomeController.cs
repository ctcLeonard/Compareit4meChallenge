using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TemperatureConverter.TemperatureService;
using TemperatureConverter.Web.Models;

namespace TemperatureConverter.Web.Controllers
{
	public class HomeController : AsyncController
	{
		TemperatureConverter converter;

		public HomeController()
		{
			converter = new TemperatureConverter();
		}

		public ActionResult Index()
		{
			TemperatureViewModel viewModel = new TemperatureViewModel();

			return View(viewModel);
		}

		/// <summary>
		/// Calls our service implementation of the Calculate Webservice asynchronously
		/// </summary>
		[HttpPost]
		public async Task<ActionResult> CalculateAsync(TemperatureViewModel viewModel)
		{
			viewModel.Result = await converter.ConvertAsync(viewModel.Amount, (TemperatureUnit)viewModel.SelectedFrom, (TemperatureUnit)viewModel.SelectedTo);

			return View("Index", viewModel);
		}
	}
}