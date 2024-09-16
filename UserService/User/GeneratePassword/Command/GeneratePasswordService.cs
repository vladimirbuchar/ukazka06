using Core.Base.Command;
using System.Text;

namespace UserService.User.GeneratePassword.Command
{
    public class GeneratePasswordService : BaseCommand, IGeneratePasswordService
    {
        public Task<string> Execute()
        {
            return Task.FromResult(GeneratePassword(8));
        }

        private static string GeneratePassword(int length)
        {
            const string upperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string lowerCase = "abcdefghijklmnopqrstuvwxyz";
            const string digits = "0123456789";
            const string specialChars = "!@#$%^&*()_+-=[]{}|;:,.<>?";

            string allChars = upperCase + lowerCase + digits + specialChars;
            StringBuilder password = new();
            Random random = new();

            // Ensure the password contains at least one character from each character set
            _ = password.Append(upperCase[random.Next(upperCase.Length)]);
            _ = password.Append(lowerCase[random.Next(lowerCase.Length)]);
            _ = password.Append(digits[random.Next(digits.Length)]);
            _ = password.Append(specialChars[random.Next(specialChars.Length)]);

            // Fill the rest of the password length with random characters
            for (int i = password.Length; i < length; i++)
            {
                _ = password.Append(allChars[random.Next(allChars.Length)]);
            }

            // Shuffle the password to ensure random order
            return Shuffle(password.ToString());
        }

        private static string Shuffle(string input)
        {
            char[] array = input.ToCharArray();
            Random random = new();
            for (int i = array.Length - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                (array[j], array[i]) = (array[i], array[j]);
            }
            return new string(array);
        }
    }
}
