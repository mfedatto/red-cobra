using RedCobra.Domain.User;

namespace RedCobra.Domain.MainDbContext;

public interface IUnitOfWork : IDisposable
{
    IUserRepository UserRepository { get; }

    Task BeginTransactionAsync();
    Task CommitAsync();
    Task RollbackAsync();
}
