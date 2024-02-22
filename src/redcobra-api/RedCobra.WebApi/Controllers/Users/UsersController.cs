using Microsoft.AspNetCore.Mvc;
using RedCobra.Domain.Exceptions;
using RedCobra.Domain.User;
using RedCobra.Domain.Wrappers;
using RedCobra.WebApi.Constants;
using RedCobra.WebApi.Extensions;

namespace RedCobra.WebApi.Controllers.Users;

[Route(RouteTemplates.Users_v1.Controller)]
public class UsersController : Controller
{
    private readonly ILogger<UsersController> _logger;
    private readonly IUserApplication _application;
    private readonly UserFactory _factory;

    public UsersController(
        ILogger<UsersController> logger,
        IUserApplication application,
        UserFactory factory)
    {
        _logger = logger;
        _application = application;
        _factory = factory;
    }
    
    [HttpGet(RouteTemplates.Users_v1.GetUsersList)]
    public async Task<ActionResult<PagedListWrapper<GetUserResponseModel>>> GetUsersList(
        [FromQuery(Name = NamedArgs.UserName)] string username,
        [FromQuery(Name = NamedArgs.UserAdmin)] bool? admin,
        [FromQuery(Name = NamedArgs.UserFullname)] string fullName,
        [FromQuery(Name = NamedArgs.UserEmail)] string email,
        [FromQuery(Name = NamedArgs.Skip)] int skip,
        [FromQuery(Name = NamedArgs.Limit)] int limit,
        CancellationToken cancellationToken)
    {
        return Ok(
            (await _application.GetUsersList(
                username,
                admin,
                fullName,
                email,
                skip,
                limit,
                cancellationToken)
                .ConfigureAwait(false))
            .WrapUp(user => user.ToGetUserResponseModel()));
    }
    
    [HttpPost(RouteTemplates.Users_v1.PostUser)]
    public async Task<ActionResult<PostUserResponseModel>> PostUser(
        [FromBody] PostUserRequestModel requestModel,
        CancellationToken cancellationToken)
    {
        string decodedCredentials = requestModel.Credentials.DecodeBase64();
        
        if (!decodedCredentials.Contains(':'))
            throw new BadCredentialsException();
        
        string[] decodedCredentialsParts = decodedCredentials.Split(':');
        
        return Ok(
            await _application.AddUser(
                _factory.ToUser(
                    requestModel,
                    decodedCredentialsParts[0]),
                decodedCredentialsParts[1],
                cancellationToken));
    }
    
    [HttpGet(RouteTemplates.Users_v1.GetUser)]
    public async Task<ActionResult<GetUserResponseModel>> GetUser(
        CancellationToken cancellationToken,
        [FromQuery(Name = NamedArgs.UserId)] Guid userId)
    {
        return Ok(
            await _application.GetUser(
                userId,
                cancellationToken));
    }
    
    [HttpPut(RouteTemplates.Users_v1.PutUser)]
    public async Task<ActionResult> PutUser(
        CancellationToken cancellationToken,
        [FromQuery(Name = NamedArgs.UserId)] Guid userId,
        [FromBody] PutUserRequestModel requestModel)
    {
        string decodedCredentials = requestModel.Credentials.DecodeBase64();
        
        if (!decodedCredentials.Contains(':'))
            throw new BadCredentialsException();
        
        string[] decodedCredentialsParts = decodedCredentials.Split(':');
        
        await _application.UpdateUser(
            _factory.ToUser(
                userId,
                requestModel,
                decodedCredentialsParts[0]),
            decodedCredentialsParts[1],
            cancellationToken);
    
        return Ok();
    }
    
    [HttpDelete(RouteTemplates.Users_v1.DeleteUser)]
    public async Task<ActionResult> DeleteUser(
        CancellationToken cancellationToken,
        [FromQuery(Name = NamedArgs.UserId)] Guid userId)
    {
        await _application.DeleteUser(
            userId,
            cancellationToken);
        
        return Ok();
    }
}
