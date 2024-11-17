using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MTKDotNetCore.MiniKpay.Database.Models.User;
using MTKDotNetCore.MiniKpay.Domain.BusinessLogic.User;

namespace MTKDotNetCore.MiniKpay.Api.Controllers
{
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
        public IActionResult GetUserList()
        {
            var users = _bL_User.GetUserList();
            if (users is null)
            {
                return NotFound("No users found.");
            }
            return Ok(users);
        }

        #endregion

        #region Get User By Id

        [HttpGet("{userId}")]
        public IActionResult GetUser(int userId)
        {
            var user = _bL_User.GetUserByUserId(userId);
            if (user is null)
            {
                return NotFound("User not found.");
            }
            return Ok(user);
        }

        #endregion

        #region CreateUser

        [HttpPost]
        public IActionResult CreateUser(UserResponseModel responseModel)
        {
            var result = _bL_User.CreateUser(responseModel);
            if(result is null)
            {
                return BadRequest("Registration Fail.");
            }
            return Ok("Registration Successful.");
        }

        #endregion

        #region UpdateUser

        [HttpPut("{userId}")]
        public IActionResult UpdateUser(int userId, UserRequestModel user)
        {
            var result = _bL_User.UpdateUser(userId, user);
            if (result is null)
            {
                return BadRequest("Updating Fail.");
            }
            return Ok("Updating Successful.");
        }

        #endregion

        #region DeleteUser

        [HttpDelete("{userId}")]
        public IActionResult DeleteUser(int userId)
        {
            var result = _bL_User.DeleteUser(userId);
            if (result is null)
            {
                return BadRequest("Deleting Failed.");
            }
            return Ok("Deleting Successful.");
        }

        #endregion
    }
}
