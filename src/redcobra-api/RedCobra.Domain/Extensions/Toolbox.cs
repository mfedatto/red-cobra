using System.Text;

namespace RedCobra.Domain.Extensions;

public static class Toolbox
{
    public static string PinchOfSalt(
        int min = 6,
        int max = 10)
    {
        Random random = new();
        int saltLength = random.Next(min, max);
        StringBuilder saltBuilder = new();
        
        for (int i = 0; i < saltLength; i++)
        {
            char randomChar = Convert.ToChar(random.Next(0, 26) + 65);
            string randomString;
            
            if (random.Next(100) > 50)
                randomString = randomChar.ToString().ToLower();
            else
                randomString = randomChar.ToString().ToUpper();
            
            saltBuilder.Append(randomString);
        }

        return saltBuilder.ToString();
    }
}
