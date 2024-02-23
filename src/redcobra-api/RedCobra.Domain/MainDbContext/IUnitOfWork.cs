using RedCobra.Domain.Licenses;
using RedCobra.Domain.User;

namespace RedCobra.Domain.MainDbContext;

public interface IUnitOfWork : IDisposable
{
    IUserRepository UserRepository { get; }
    ILicenseRepository LicenseRepository { get; }

    Task BeginTransactionAsync();
    Task CommitAsync();
    Task RollbackAsync();
}
