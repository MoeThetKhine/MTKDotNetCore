namespace MTKDotNetCore.MiniKpay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public IActionResult Execute(object model)
        {
            JObject jObj = JObject.Parse(JsonConvert.SerializeObject(model));
            if(jObj.ContainsKey("Response"))
            {
                BaseResponseModel baseResponseModel = JsonConvert.DeserializeObject<BaseResponseModel>(jObj["Response"]!.ToString())!;

                if (baseResponseModel.RespType == EnumRespType.ValidationError)
                    return BadRequest(model);

                if(baseResponseModel.RespType == EnumRespType.SystemError)
                    return BadRequest(model);

                return Ok(model);
            }
            return StatusCode(500, "Invalid Response Model.Please add BaseResponseModel to your ResponseModel.");
        }
    }
}
