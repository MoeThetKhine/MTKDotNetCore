using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MTKDotNetCore.MiniKpayDapperApi.Controllers
{
    [Route("api/[user]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly string _connectionString = "Data Source=.;Initial Catalog=MiniKpay;User ID=sa;Password=sasa@123;TrustServerCertificate=True;";
    }
}
