namespace RedCobra.Domain.Exceptions;

public static class ExceptionsExtensions
{
    public static void ThrowIfClientClosedRequest(this CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested) throw new RequestClosedException();
    }
}