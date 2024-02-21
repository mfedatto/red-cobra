namespace RedCobra.Domain.MainDbContext;

public interface IUnitOfWork : IDisposable
{
    //// IAplicacaoRepository AplicacaoRepository { get; }
    //// ITipoRepository TipoRepository { get; }
    //// IChaveRepository ChaveRepository { get; }
    //// IValorRepository ValorRepository { get; }

    Task BeginTransactionAsync();
    Task CommitAsync();
    Task RollbackAsync();
}
