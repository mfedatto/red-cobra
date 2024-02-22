using Microsoft.AspNetCore.Mvc;
using RedCobra.WebApi.Constants;

namespace RedCobra.WebApi.Controllers.Licenses;

[Route(RouteTemplates.Licenses_v1.Controller)]
public class LicensesController : Controller
{
    [HttpGet(RouteTemplates.Users_v1.GetUsersList)]
    public async Task<ActionResult> GetLicensesList(
        CancellationToken cancellationToken)
    {
        return Ok();
    }
}