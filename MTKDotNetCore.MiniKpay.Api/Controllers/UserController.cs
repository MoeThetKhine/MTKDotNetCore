namespace MTKDotNetCore.MiniKpay.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : BaseController
{
    private readonly BusinessLogic_User _bL_User;

    public UserController(BusinessLogic_User businessLogic_User)
    {
        _bL_User = businessLogic_User;
    }

    #region Get User List

    [HttpGet]
    public async Task<IActionResult> GetUserListAsync()
    {
        var result = await _bL_User.GetUserListAsync();

        if (result.IsError)
        {
            return result.Type == EnumRespType.ValidationError
                ? BadRequest(result.Message)
                : StatusCode(500, result.Message);
        }

        return Ok(result.Data);
    }

    #endregion

    #region Get User By Id

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetUser(int userId)
    {
        var result = await _bL_User.GetUserByUserIdAsync(userId);

        if (result.IsError)
        {
            return result.Type == EnumRespType.ValidationError
                ? NotFound(result.Message)
                : StatusCode(500, result.Message);
        }

        return Ok(result.Data);
    }

    #endregion

    #region Create User

    [HttpPost]
    public async Task<IActionResult> CreateUser(UserResponseModel responseModel)
    {
        var result = await _bL_User.CreateUserAsync(responseModel);

        if (result.IsError)
        {
            return result.Type == EnumRespType.ValidationError
                ? BadRequest(result.Message)
                : StatusCode(500, result.Message);
        }

        return Ok(result.Message);
    }

    #endregion

    #region Update User

    [HttpPut("{userId}")]
    public async Task<IActionResult> UpdateUser(int userId, UserRequestModel user)
    {
        var result = await _bL_User.UpdateUserAsync(userId, user);

        if (result.IsError)
        {
            return result.Type == EnumRespType.ValidationError
                ? BadRequest(result.Message)
                : StatusCode(500, result.Message);
        }

        return Ok(result.Message);
    }

    #endregion

    #region Soft Delete User

    [HttpDelete("{userId}")]
    public async Task<IActionResult> DeleteUser(int userId)
    {
        var result = await _bL_User.DeleteUserAsync(userId);

        if (result.IsError)
        {
            return result.Type == EnumRespType.ValidationError
                ? BadRequest(result.Message)
                : StatusCode(500, result.Message);
        }

        return Ok(result.Message);
    }

    #endregion

}
