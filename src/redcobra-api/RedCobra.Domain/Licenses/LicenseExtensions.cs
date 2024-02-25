using RedCobra.Domain.Extensions;

namespace RedCobra.Domain.Licenses;

public static class LicenseExtensions
{
    public static bool IsExpired(
        this ILicense license,
        int graceDays = 0)
    {
        return license.ExpirationDate < DateTime.Now
            .AddDays(graceDays)
            .ClearTime();
    }
}
