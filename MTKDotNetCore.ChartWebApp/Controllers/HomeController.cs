namespace MTKDotNetCore.ChartWebApp.Controllers;

public class HomeController : Controller
{
	private readonly ILogger<HomeController> _logger;

	public HomeController(ILogger<HomeController> logger)
	{
		_logger = logger;
	}

	#region Index

	public IActionResult Index()
	{
		return View();
	}

	#endregion

	#region Privacy

	public IActionResult Privacy()
	{
		return View();
	}

	#endregion

	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public IActionResult Error()
	{
		return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
	}
}
