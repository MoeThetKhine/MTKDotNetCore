namespace MTKDotNetCore.ChartWebApp.Models;

#region ApexChartPieChartModel

public class ApexChartPieChartModel
{
	public int[] Series { get; set; } 
	public string[] Labels { get; set; } 
}

#endregion

#region ApexChartMixedChartModel

public class ApexChartMixedChartModel
{
	public List<SeriesData> Series { get; set; }
	public string[] Labels { get; set; }
}

#endregion

#region SeriesData

public class SeriesData
{
	public string Name { get; set; }
	public string Type { get; set; }
	public int[] Data { get; set; }
}

#endregion

#region PyramidChartModel

public class PyramidChartModel
{
	public string[] Categories { get; set; }
	public int[] Data { get; set; }
}

#endregion

#region BarChartModel

public class BarChartModel
{
	public int[] Data { get; set; }
	public string[] Categories { get; set; }
}

#endregion