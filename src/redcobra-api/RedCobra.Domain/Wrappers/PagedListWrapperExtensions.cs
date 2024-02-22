namespace RedCobra.Domain.Wrappers;

public static class PagedListWrapperExtensions
{
    public static PagedListWrapper<T> WrapUp<T>(
        this IEnumerable<T>? payload,
        int skip = 0,
        int? limit = null,
        int? total = null)
    {
        int count = payload?.Count() ?? 0;
        
        return new(
            Total: total ?? count,
            Skip: skip,
            Limit: limit,
            Count: count,
            Payload: payload ?? Array.Empty<T>());
    }
    
    public static PagedListWrapper<TT> WrapUp<T, TT>(
        this IEnumerable<T>? payload,
        Func<T, TT> selector,
        int skip = 0,
        int? limit = null,
        int? total = null)
    {
        return payload.WrapUp(
            skip,
            limit,
            total)
            .WrapUp(selector);
    }
    
    public static PagedListWrapper<TT> WrapUp<T, TT>(
        this PagedListWrapper<T> wrapper,
        Func<T, TT> selector)
    {
        return new(
            Total: wrapper.Total,
            Skip: wrapper.Skip,
            Limit: wrapper.Limit,
            Count: wrapper.Count,
            Payload: wrapper.Payload
                .Select(selector));
    }
}
