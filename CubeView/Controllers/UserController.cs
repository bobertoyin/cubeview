using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace CubeView.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class UserController : ControllerBase
{

    private readonly ILogger<UserController> _logger;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public UserController(ILogger<UserController> logger, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        _logger = logger;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpPost]
    async public Task<IResult> LogoutUser()
    {
        await _signInManager.SignOutAsync();
        return Results.Ok();
    }

    [HttpGet]
    async public Task<IActionResult> CurrentUser()
    {
        IdentityUser? user = await _userManager.GetUserAsync(User);
        if (user != null) {
            return Ok(user);
        }
        return NotFound();
    }
}
