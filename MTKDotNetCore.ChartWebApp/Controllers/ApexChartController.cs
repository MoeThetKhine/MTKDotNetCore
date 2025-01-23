namespace MTKDotNetCore.ChartWebApp.Controllers;

public class ApexChartController : Controller
{

	#region PieChart

	public IActionResult PieChart()
	{
		ApexChartPieChartModel model = new ApexChartPieChartModel();
		model.Series = new int[] { 44, 55, 13, 43, 22 };
		model.Labels = new string[] { "Team A", "Team B", "Team C", "Team D", "Team E" };
		return View(model);
	}

	#endregion

	#region MixedChart

	public IActionResult MixedChart()
	{
		var model = new ApexChartMixedChartModel
		{
			Series = new List<SeriesData>
		{
			new SeriesData
			{
				Name = "TEAM A",
				Type = "column",
				Data = new int[] { 23, 11, 22, 27, 13, 22, 37, 21, 44, 22, 30 }
			},
			new SeriesData
			{
				Name = "TEAM B",
				Type = "area",
				Data = new int[] { 44, 55, 41, 67, 22, 43, 21, 41, 56, 27, 43 }
			},
			new SeriesData
			{
				Name = "TEAM C",
				Type = "line",
				Data = new int[] { 30, 25, 36, 30, 45, 35, 64, 52, 59, 36, 39 }
			}
		},
			Labels = new string[] { "01/01/2003", "02/01/2003", "03/01/2003", "04/01/2003", "05/01/2003", "06/01/2003", "07/01/2003", "08/01/2003", "09/01/2003", "10/01/2003", "11/01/2003" }
		};

		return View(model);
	}

	#endregion

	#region PyramidChart

	public ActionResult PyramidChart()
	{
		var model = new PyramidChartModel
		{
			Categories = new[]
			{
				"Sweets", "Processed Foods", "Healthy Fats", "Meat",
				"Beans & Legumes", "Dairy", "Fruits & Vegetables", "Grains"
			},
			Data = new[] { 200, 330, 548, 740, 880, 990, 1100, 1380 }
		};
		return View(model);
	}

	#endregion

	#region HorizontalBarChart

	public IActionResult HorizontalBarChart()
	{
		var model = new BarChartModel
		{
			Data = new[] { 400, 430, 448, 470, 540, 580, 690, 1100, 1200, 1380 },
			Categories = new[]
			{
					"South Korea", "Canada", "United Kingdom", "Netherlands", "Italy",
					"France", "Japan", "United States", "China", "Germany"
				}
		};

		return View(model);
	}

	#endregion

	#region ScatterChart

	public IActionResult ScatterChart()
	{
		var seriesData = new List<ScatterChartModel>
		{
			new ScatterChartModel
			{
				Name = "SAMPLE A",
				Data = new List<List<double>>
				{
					new List<double> { 16.4, 5.4 },
					new List<double> { 21.7, 2 },
					new List<double> { 25.4, 3 },
				}
			},
			new ScatterChartModel
			{
				Name = "SAMPLE B",
				Data = new List<List<double>>
				{
					new List<double> { 36.4, 13.4 },
					new List<double> { 1.7, 11 },
					new List<double> { 5.4, 8 },
				}
			},
			new ScatterChartModel
			{
				Name = "SAMPLE C",
				Data = new List<List<double>>
				{
					new List<double> { 21.7, 3 },
					new List<double> { 23.6, 3.5 },
					new List<double> { 24.6, 3 },
				}
			}
		};

		return View(seriesData);
	}

	#endregion

	#region PolarAreaChart

	public IActionResult PolarAreaChart()
	{
		var model = new PolarAreaChartModel
		{
			Series = new List<int> { 14, 23, 21, 17, 15, 10, 12, 17, 21 }
		};

		return View(model);
	}

	#endregion

	#region AreaChart

	public IActionResult AreaChart()
	{
		var model = new AreaChartModel
		{
			Dates = new List<object[]>
			{
				new object[] { "2023-01-01", 1000000 },
				new object[] { "2023-01-02", 2000000 },
				new object[] { "2023-01-03", 1500000 },
				new object[] { "2023-01-04", 3000000 },
				new object[] { "2023-01-05", 2500000 }
			}
		};

		return View(model);
	}

	#endregion

	#region RangeBarChart

	public IActionResult RangeBarChart()
	{
		var chartData = new List<RangeBarChartModel>
		{
			new RangeBarChartModel { Department = "Operations", PayRange = new[] { 2800, 4500 } },
			new RangeBarChartModel { Department = "Customer Success", PayRange = new[] { 3200, 4100 } },
			new RangeBarChartModel { Department = "Engineering", PayRange = new[] { 2950, 7800 } },
			new RangeBarChartModel { Department = "Marketing", PayRange = new[] { 3000, 4600 } },
			new RangeBarChartModel { Department = "Product", PayRange = new[] { 3500, 4100 } },
			new RangeBarChartModel { Department = "Data Science", PayRange = new[] { 4500, 6500 } },
			new RangeBarChartModel { Department = "Sales", PayRange = new[] { 4100, 5600 } }
		};

		return View(chartData);
	}

	#endregion


}
