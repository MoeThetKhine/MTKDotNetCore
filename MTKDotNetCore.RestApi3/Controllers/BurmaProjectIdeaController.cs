namespace MTKDotNetCore.RestApi3.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BurmaProjectIdeaController : ControllerBase
{
    private readonly HttpClient _httpClient;
    private readonly RestClient _restClient;
    private readonly ISnakeApi _snakeApi;

    public BurmaProjectIdeaController(HttpClient httpClient, RestClient restClient, ISnakeApi snakeApi)
    {
        _httpClient = httpClient;
        _restClient = restClient;
        _snakeApi = snakeApi;
    }

    #region BirdAsync

    [HttpGet("birds")]
    public async Task<IActionResult> BirdAsync()
    {
        var response = await _httpClient.GetAsync("birds");
        string str = await response.Content.ReadAsStringAsync();
        return Ok(str);
    }

    #endregion

    #region PickAPileAsync

    [HttpGet("pick-a-pile")]
    public async Task<IActionResult> PickAPileAsync()
    {
        RestRequest request = new RestRequest("pick-a-pile", Method.Get);
        var response = await _restClient.GetAsync(request);
        return Ok(response.Content);
    }

    #endregion

    #region Snakes

    [HttpGet("snakes")]
    public async Task<IActionResult> Snakes()
    {
        var response = await _snakeApi.GetSnakes();
        return Ok(response);
    }

    #endregion

}
