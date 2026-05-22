using System.Security.Cryptography;
using System.Text;
using ZooApp.Domain.Models;

namespace ZooApp.Services
{
    public static class PasswordHelper
    {
        public static string Hash(string password)
        {
            using SHA256 sha256 = SHA256.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            byte[] hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        public static void ValidateAndHash(UserModel user)
        {
            //ArgumentNullException.ThrowIfNull(user);

            //if (string.IsNullOrWhiteSpace(user.Name))
            //    throw new ArgumentException("Navn er påkrævet.", nameof(user));

            //if (string.IsNullOrWhiteSpace(user.Telefon))
            //    throw new ArgumentException("Telefonnummer er påkrævet.", nameof(user));

            //if (string.IsNullOrWhiteSpace(user.Email))
            //    throw new ArgumentException("Email er påkrævet.", nameof(user));

            //if (!user.Email.EndsWith("@edu.zealand.dk", StringComparison.OrdinalIgnoreCase))
            //    throw new ArgumentException("Email skal være en Zealand email (f.eks. eksempel@edu.zealand.dk).", nameof(user));

            //if (string.IsNullOrWhiteSpace(user.PwHash))
            //    throw new ArgumentException("Adgangskode er påkrævet.", nameof(user));

            user.PwHash = Hash(user.PwHash);
        }
    }
}