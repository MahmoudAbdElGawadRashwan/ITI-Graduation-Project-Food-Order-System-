using FoodOrderSystemAPI.BL;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrderSystemAPI.Controllers;

    [Route("api/[controller]")]
    [ApiController]
   
public class LoginController : Controller
{
    public IAuthenticationManager _AuthenticationManager { get; set; }
   

    public LoginController(IAuthenticationManager authenticationManager)
    {
        _AuthenticationManager = authenticationManager;
    }

    [HttpPost]
    
    public async Task<ActionResult<string>> LoginAsUser(UserLogin UserToLogin)
    {
        var LoginResult = await _AuthenticationManager.LoginAsUser(UserToLogin);
        if (LoginResult == null)
        {
            return Unauthorized(LoginResult);
        }
        return Ok(LoginResult);
    }
   

}
