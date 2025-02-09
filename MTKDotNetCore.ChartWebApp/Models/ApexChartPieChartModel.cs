﻿namespace MTKDotNetCore.ChartWebApp.Models;

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

#region ScatterChartModel

public class ScatterChartModel
{
	public string Name { get; set; } 
	public List<List<double>> Data { get; set; } 
}

#endregion

#region PolarAreaChartModel

public class PolarAreaChartModel
{
	public List<int> Series { get; set; }
}

#endregion

#region AreaChartModel

public class AreaChartModel
{
	public List<object[]> Dates { get; set; } 
}

#endregion

#region RangeBarChartModel

public class RangeBarChartModel
{
	public string Department { get; set; } 
	public int[] PayRange { get; set; }    
}

#endregion

#region RadialBarChartModel

public class RadialBarChartModel
{
	public int Percentage { get; set; } 
}

#endregion