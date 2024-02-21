using Microsoft.AspNetCore.Mvc;
using RedCobra.Domain.Wrappers;
using RedCobra.WebApi.Constants;

namespace RedCobra.WebApi.Controllers.Users;

[Route(RouteTemplates.Users_v1.Controller)]
public class UsersController : Controller
{
    [HttpGet(RouteTemplates.Users_v1.GetUsersList)]
    public async Task<ActionResult<PagedListWrapper<GetUserResponseModel>>> GetUsersList(
        CancellationToken cancellationToken,
        [FromQuery(Name = NamedArgs.UserName)] string? username = null,
        [FromQuery(Name = NamedArgs.UserAdmin)] bool? admin = null,
        [FromQuery(Name = NamedArgs.UserFullname)] string? fullName = null,
        [FromQuery(Name = NamedArgs.UserEmail)] string? email = null)
    {
        return Ok();
    }
}
