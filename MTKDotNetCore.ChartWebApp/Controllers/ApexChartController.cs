using Microsoft.AspNetCore.Mvc;

namespace MTKDotNetCore.ChartWebApp.Controllers
{
	public class ApexChartController : Controller
	{
		public IActionResult PieChart()
		{
			return View();
		}
	}
}
