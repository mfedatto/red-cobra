using Microsoft.AspNetCore.Mvc;
using RedCobra.WebApi.Constants;

namespace RedCobra.WebApi.Controllers.Users;

[Route($"{RouteTemplates.Users_v1.Version}/{RouteTemplates.Users_v1.Controller}")]
public class UsersController : Controller
{
    public async Task<ActionResult> GetUsersList()
    {
        return Ok();
    }
}
