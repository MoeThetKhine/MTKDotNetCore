namespace MTKDotNetCore.ChartWebApp.Models;

#region ApexChartPieChartModel

public class ApexChartPieChartModel
{
	public int[] Series { get; set; } 
	public string[] Labels { get; set; } 
}

#endregion

public class ApexChartMixedChartModel
{
	public List<SeriesData> Series { get; set; }
	public string[] Labels { get; set; }
}

public class SeriesData
{
	public string Name { get; set; }
	public string Type { get; set; }
	public int[] Data { get; set; }
}
