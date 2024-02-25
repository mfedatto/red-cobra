using System.Security.Cryptography;
using System.Text;

namespace RedCobra.Domain.Extensions;

public static class CoreExtensions
{
    public static string Sha256Hash(
        this string content,
        string salt = "")
    {
        using (SHA256 sha256Hash = SHA256.Create())
        {
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(content + salt));

            StringBuilder hashBuilder = new();
            
            for (int i = 0; i < bytes.Length; i++)
            {
                hashBuilder.Append(bytes[i].ToString("x2"));
            }
            
            return hashBuilder.ToString();
        }
    }
    
    public static DateTime ClearTime(
        this DateTime date)
    {
        return new DateTime(
            date.Year, date.Month, date.Day,
            0, 0, 0);
    }
}
