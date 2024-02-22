namespace RedCobra.WebApi.Extensions;

public static class StringExtensions
{
    public static string DecodeBase64(this string base64EncodedData)
    {
        return System.Text.Encoding
            .UTF8
            .GetString(
                Convert.FromBase64String(base64EncodedData));
    }
}
