using Microsoft.AspNetCore.Mvc;
using MTKDotNetCore.ChartWebApp.Models;

namespace MTKDotNetCore.ChartWebApp.Controllers
{
	public class ApexChartController : Controller
	{
		public IActionResult PieChart()
		{
			ApexChartPieChartModel model = new ApexChartPieChartModel();
			model.Series = new int[] { 44, 55, 13, 43, 22 };
			model.Labels = new string[] { "Team A", "Team B", "Team C", "Team D", "Team E" };
			return View(model);
		}
	}
}
