using Microsoft.AspNetCore.Mvc;
using RedCobra.Domain.BasicAuthentication;
using RedCobra.Domain.User;
using RedCobra.Domain.Wrappers;
using RedCobra.WebApi.Constants;

namespace RedCobra.WebApi.Controllers.Users;

[Route(RouteTemplates.Users_v1.Controller)]
public class UsersController : Controller
{
    private readonly ILogger<UsersController> _logger;
    private readonly IUserApplication _application;
    private readonly UserFactory _factory;
    private readonly BasicAuthenticationFactory _basicAuthenticationFactory;

    public UsersController(
        ILogger<UsersController> logger,
        IUserApplication application,
        UserFactory factory,
        BasicAuthenticationFactory basicAuthenticationFactory)
    {
        _logger = logger;
        _application = application;
        _factory = factory;
        _basicAuthenticationFactory = basicAuthenticationFactory;
    }
    
    [HttpGet(RouteTemplates.Users_v1.GetUsersList)]
    public async Task<ActionResult<PagedListWrapper<GetUserResponseModel>>> GetUsersList(
        CancellationToken cancellationToken,
        [FromQuery(Name = NamedArgs.UserName)] string? username = null,
        [FromQuery(Name = NamedArgs.UserAdmin)] bool? admin = null,
        [FromQuery(Name = NamedArgs.UserFullname)] string? fullName = null,
        [FromQuery(Name = NamedArgs.UserEmail)] string? email = null,
        [FromQuery(Name = NamedArgs.Skip)] int skip = 0,
        [FromQuery(Name = NamedArgs.Limit)] int? limit = null)
    {
        return Ok(
            (await _application.GetUsersList(
                cancellationToken,
                username,
                admin,
                fullName,
                email,
                skip,
                limit))
            .WrapUp(user => user.ToGetUserResponseModel()));
    }
    
    [HttpPost(RouteTemplates.Users_v1.PostUser)]
    public async Task<ActionResult<PostUserResponseModel>> PostUser(
        CancellationToken cancellationToken,
        [FromBody] PostUserRequestModel requestModel,
        [FromHeader(Name = "Authorization")] string basicAuthenticationCredentials)
    {
        IBasicAuthenticationCredentials basicAuthenticationCredentialsModel =
            _basicAuthenticationFactory.Create(basicAuthenticationCredentials);
        
        return Ok(
            await _application.AddUser(
                cancellationToken,
                _factory.ToUser(
                    requestModel,
                    basicAuthenticationCredentialsModel.Username),
                basicAuthenticationCredentialsModel.Password));
    }
    
    [HttpGet(RouteTemplates.Users_v1.GetUser)]
    public async Task<ActionResult<GetUserResponseModel>> GetUser(
        CancellationToken cancellationToken,
        [FromQuery(Name = NamedArgs.UserId)] Guid userId)
    {
        return Ok(
            await _application.GetUser(
                cancellationToken,
                userId));
    }
    
    [HttpPut(RouteTemplates.Users_v1.PutUser)]
    public async Task<ActionResult> PutUser(
        CancellationToken cancellationToken,
        [FromQuery(Name = NamedArgs.UserId)] Guid userId,
        [FromBody] PutUserRequestModel requestModel,
        [FromHeader(Name = "Authorization")] string basicAuthenticationCredentials)
    {
        IBasicAuthenticationCredentials basicAuthenticationCredentialsModel =
            _basicAuthenticationFactory.Create(basicAuthenticationCredentials);

        await _application.UpdateUser(
            cancellationToken,
            _factory.ToUser(
                userId,
                requestModel,
                basicAuthenticationCredentialsModel.Username),
            basicAuthenticationCredentialsModel.Password);
    
        return Ok();
    }
    
    [HttpDelete(RouteTemplates.Users_v1.DeleteUser)]
    public async Task<ActionResult> DeleteUser(
        CancellationToken cancellationToken,
        [FromQuery(Name = NamedArgs.UserId)] Guid userId)
    {
        await _application.DeleteUser(
            cancellationToken,
            userId);
        
        return Ok();
    }
}
