using RedCobra.Domain.BasicAuthentication;
using RedCobra.Domain.User;

namespace RedCobra.WebApi.Controllers.Users;

public static class ModelExtensions
{
    public static IUser ToUser(
        this UserFactory factory,
        PostUserRequestModel requestModel,
        string username)
    {
        return factory.Create(
            Guid.Empty,
            username,
            requestModel.Admin,
            requestModel.FullName,
            requestModel.Email);
    }
    
    public static IUser ToUser(
        this UserFactory factory,
        Guid userId,
        PutUserRequestModel requestModel,
        string username)
    {
        return factory.Create(
            Guid.Empty,
            username,
            requestModel.Admin,
            requestModel.FullName,
            requestModel.Email);
    }
    
    public static GetUserResponseModel ToGetUserResponseModel(
        this IUser user)
    {
        return new(
            user.UserId,
            user.Username,
            user.Admin,
            user.FullName,
            user.Email
        );
    }
}
