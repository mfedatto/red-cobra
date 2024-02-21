namespace RedCobra.Domain.Wrappers;

public record PagedListWrapper<T>(
    int Total,
    int Skip,
    int? Limit,
    int Count,
    IEnumerable<T> Payload) { }
