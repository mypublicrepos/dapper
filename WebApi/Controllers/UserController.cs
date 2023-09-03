using Microsoft.AspNetCore.Mvc;
using WebApi.Business.Contract;
using WebApi.Models.Request;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> logger;
    private readonly IUserBusiness userBusiness;

    public UserController(ILogger<UserController> logger, IUserBusiness userBusiness)
    {
        this.logger = logger;
        this.userBusiness = userBusiness;
    }

    /// <summary> </summary>
    /// <param name="userModel"></param>
    /// <returns></returns>
    [HttpPost("register")]
    public async Task<IActionResult> Login([FromBody] UserModel userModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var response = await userBusiness.SaveuserAsync(userModel);
        return Ok(response);
    }

    /// <summary> </summary>
    /// <param name="userLoginModel"></param>
    /// <returns></returns>
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginModel userLoginModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var response = await userBusiness.LoginAsync(userLoginModel);
        return Ok(response);
    }
}
