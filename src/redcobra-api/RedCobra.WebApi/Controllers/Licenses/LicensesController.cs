using Microsoft.AspNetCore.Mvc;
using RedCobra.Domain.Licenses;
using RedCobra.WebApi.Constants;

namespace RedCobra.WebApi.Controllers.Licenses;

[Route(RouteTemplates.Licenses_v1.Controller)]
public class LicensesController : Controller
{
    private readonly ILogger<LicensesController> _logger;
    private readonly ILicenseApplication _application;
    private readonly LicenseFactory _factory;

    public LicensesController(
        ILogger<LicensesController> logger,
        ILicenseApplication application,
        LicenseFactory factory)
    {
        _logger = logger;
        _application = application;
        _factory = factory;
    }

    [HttpGet(RouteTemplates.Licenses_v1.GetLicensesList)]
    public async Task<ActionResult<GetLicenseResponseModel[]>> GetLicensesList(
        [FromRoute(Name = NamedArgs.UserId)] Guid userId,
        string licenseNumber,
        bool? aCategory,
        bool? bCategory,
        bool includeExpired,
        CancellationToken cancellationToken)
    {
        return Ok((await _application.GetUserLicensesList(
                    userId,
                    aCategory,
                    bCategory,
                    includeExpired,
                    cancellationToken)
                .ConfigureAwait(false))
            .Select(license => license.ToGetLicenseResponseModel()));
    }

    [HttpPost(RouteTemplates.Licenses_v1.PostLicense)]
    public async Task<ActionResult<PostLicenseResponseModel>> PostLicense(
        [FromRoute(Name = NamedArgs.UserId)] Guid userId,
        [FromBody] PostLicenseRequestModel requestModel,
        CancellationToken cancellationToken)
    {
        return Ok(
            (await _application.AddLicense(
                    _factory.Create(
                        requestModel.LicenseId,
                        requestModel.LicenseNumber,
                        userId,
                        requestModel.ExpirationDate,
                        requestModel.ACategory,
                        requestModel.BCategory,
                        requestModel.DateOfBirth,
                        requestModel.LicenseFileId,
                        requestModel.Issuer,
                        requestModel.IssueDate),
                    cancellationToken)
                .ConfigureAwait(false))
            .ToPostLicenseResponseModel());
    }
}
