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
    private readonly UserManager<CubeReviewer> _userManager;
    private readonly SignInManager<CubeReviewer> _signInManager;

    public UserController(ILogger<UserController> logger, UserManager<CubeReviewer> userManager, SignInManager<CubeReviewer> signInManager)
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
        CubeReviewer? user = await _userManager.GetUserAsync(User);
        if (user != null) {
            ReviewerView userView = new ReviewerView{
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Joined = user.Joined,
            };
            return Ok(userView);
        }
        return NotFound();
    }
}
