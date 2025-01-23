namespace MTKDotNetCore.ChartWebApp.Models
{
	public class ApexChartPieChartModel
	{
		public int[] Series { get; set; } 
		public string[] Labels { get; set; } 
	}

	public class ApexChartMixedChartModel
	{
		public List<SeriesData> Series { get; set; }
		public string[] Labels { get; set; }
	}
}
