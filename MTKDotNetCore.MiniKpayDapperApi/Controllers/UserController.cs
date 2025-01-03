﻿namespace MTKDotNetCore.MiniKpayDapperApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly DapperService _dapperService;

    public UserController(DapperService dapperService)
    {
        _dapperService = dapperService;
    }

    #region GetUserList

    [HttpGet]
    public IActionResult GetUserList()
    {
        string query = "SELECT * FROM Tbl_User WHERE DeleteFlag = 0;";
        var users = _dapperService.Query<UserModel>(query);

        if (users is null)
        {
            return NotFound("No active users found.");
        }
        return Ok(users);
    }

    #endregion

    #region Get User By Id

    [HttpGet("{userid}")]
    public IActionResult GetUser(int userid)
    {
        string query = "SELECT * FROM Tbl_User WHERE User_Id = @User_Id AND DeleteFlag = 0;";

        var user = _dapperService.QueryFirstOrDefault<UserModel>(query, new { User_Id = userid });

        if (user is null)
        {
            return NotFound("No Data Found.");
        }
        return Ok(user);
    }

    #endregion

    #region Create User(Register)

    [HttpPost]
    public IActionResult CreateUser(UserResponseModel responseModel)
    {

        #region duplicate Phone Number

        string checkPhoneNumberQuery = "SELECT * FROM Tbl_User WHERE PhoneNumber = @PhoneNumber AND DeleteFlag = 0;";
        var phoneExists = _dapperService.QueryFirstOrDefault<int>(checkPhoneNumberQuery, new { PhoneNumber = responseModel.PhoneNumber });

        #endregion

        #region Duplicate Pin

        string pinCheckQuery = "SELECT FROM Tbl_User WHERE Pin = @Pin AND DeleteFlag = 0;";
        var isPinExists = _dapperService.QueryFirstOrDefault<int>(pinCheckQuery, new { responseModel.Pin });

        #endregion

        #region Validation For User Registration

        if (phoneExists > 0)
        {
            return BadRequest("Phone number already exists. Please use a different phone number.");
        }
        if (responseModel.PhoneNumber.Length > 10)
        {
            return BadRequest("Phone number must be only 10 numbers.");
        }

        if (responseModel.Pin.Length != 8)
        {
            return BadRequest("Pin must be exactly 8 characters long.");
        }

        if (responseModel.Balance < 0)
        {
            return BadRequest("Balance must be greater than or equal to 0.");
        }
        if(responseModel.Balance < 10000)
        {
            return BadRequest("Balance must be at least 10000 Kyats");
        }

        if (isPinExists > 0)
        {
            return BadRequest("This Pin is already used by another user. Please choose a different Pin.");
        }

        #endregion 

        string query = @"INSERT INTO [dbo].[Tbl_User]
           ([FullName]
           ,[Password]
           ,[Pin]
           ,[PhoneNumber]
           ,[Balance]
           ,[DeleteFlag])
     VALUES
           (@FullName
           ,@Password
           ,@Pin
           ,@PhoneNumber
           ,@Balance
           ,0)";

        int result = _dapperService.Execute(query, responseModel);

        return Ok(result == 1 ? "User registration successful." : "User registration failed.");
    }

    #endregion

    #region UpdateUser

    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, UserRequestModel user)
    {
        string checkUserQuery = "SELECT * FROM Tbl_User WHERE User_Id = @UserId AND DeleteFlag = 0;";
        var userExists = _dapperService.QueryFirstOrDefault<int>(checkUserQuery, new { UserId = id });

        if (userExists == 0)
        {
            return NotFound("User not found.");
        }

        string phoneCheckQuery = "SELECT * FROM Tbl_User WHERE PhoneNumber = @PhoneNumber AND User_Id != @UserId AND DeleteFlag = 0;";
        var phoneExists = _dapperService.QueryFirstOrDefault<int>(phoneCheckQuery, new { PhoneNumber = user.PhoneNumber, UserId = id });

        if (phoneExists > 0)
        {
            return BadRequest("The phone number is already in use by another user.");
        }

        string updateQuery = @"
        UPDATE [dbo].[Tbl_User]
        SET FullName = @FullName,
            Pin = @Pin,
            PhoneNumber = @PhoneNumber,
            DeleteFlag = 0
        WHERE User_Id = @UserId;";

        int result = _dapperService.Execute(updateQuery, new
        {
            UserId = id,
            FullName = user.FullName,
            PhoneNumber = user.PhoneNumber,
            Pin = user.Pin
        });

        return Ok(result == 1 ? "Updating Successful." : "Updating Failed.");
    }

    #endregion

    #region Soft Delete User

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        string checkUserQuery = "SELECT * FROM Tbl_User WHERE User_Id = @UserId AND DeleteFlag = 0;";
        var user = _dapperService.QueryFirstOrDefault<int>(checkUserQuery, new { UserId = id });

        if (user == 0)
        {
            return NotFound("User not found.");
        }

        string query = "UPDATE [dbo].[Tbl_User] SET DeleteFlag = 1 WHERE User_Id = @UserId;";
        int result = _dapperService.Execute(query, new { UserId = id });

        return Ok(result == 1 ? "Logout successfully." : "Logout Failed");
    }

    #endregion

}
