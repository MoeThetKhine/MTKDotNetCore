using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MTKDotNetCore.MiniKpayDapperApi.Models.User;

namespace MTKDotNetCore.MiniKpayDapperApi.Controllers
{
    [Route("api/[user]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly string _connectionString = "Data Source=.;Initial Catalog=MiniKpay;User ID=sa;Password=sasa@123;TrustServerCertificate=True;";
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
    }
}
