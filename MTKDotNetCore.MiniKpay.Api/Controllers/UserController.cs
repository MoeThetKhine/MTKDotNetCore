namespace MTKDotNetCore.MiniKpay.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly BusinessLogic_User _bL_User;

    public UserController(BusinessLogic_User businessLogic_User)
    {
        _bL_User = businessLogic_User;
    }

    #region GetUserList

    [HttpGet]
    public async Task<IActionResult> GetUserListAsync()
    {
        var users = await _bL_User.GetUserListAsync();
        if (users is null)
        {
            return NotFound("No users found.");
        }
        return Ok(users);
    }

    #endregion

    #region Get User By Id

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetUser(int userId)
    {
        var user = await _bL_User.GetUserByUserIdAsync(userId);
        if (user is null)
        {
            return NotFound("User not found.");
        }
        return Ok(user);
    }

    #endregion

    #region CreateUser

    [HttpPost]
    public async Task<IActionResult> CreateUser(UserResponseModel responseModel)
    {
        var result = await _bL_User.CreateUserAsync(responseModel);
        if (result is null)
        {
            return BadRequest("Registration failed.");
        }
        return Ok("Registration successful.");
    }

    #endregion

    #region UpdateUser

    [HttpPut("{userId}")]
    public async Task<IActionResult> UpdateUser(int userId, UserRequestModel user)
    {
        var result = await _bL_User.UpdateUserAsync(userId, user);
        if (result is null)
        {
            return BadRequest("Updating failed.");
        }
        return Ok("Updating successful.");
    }

    #endregion

    #region Soft Delete User

    [HttpDelete("{userId}")]
    public async Task<IActionResult> DeleteUser(int userId)
    {
        var result = await _bL_User.DeleteUserAsync(userId);
        if (result is null)
        {
            return BadRequest("Deleting failed.");
        }
        return Ok("Deleting successful.");
    }

    #endregion

}
