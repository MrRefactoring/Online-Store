using System;
namespace Pr.handlers
{
    public class Tokenizer
    {
        public static string getToken(){  // Метод генерирует случайный токен для нового пользователя
            Guid g = Guid.NewGuid();
            string GuidString = Convert.ToBase64String(g.ToByteArray());
            GuidString = GuidString.Replace("=", "");
            GuidString = GuidString.Replace("+", "");
            return GuidString;
        }

    }
}
