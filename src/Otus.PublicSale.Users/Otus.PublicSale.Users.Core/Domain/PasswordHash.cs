using System;

namespace Otus.PublicSale.Users.Core.Domain
{
    /// <summary>
    /// Password Hash
    /// </summary>
    public static class PasswordHash
    {
        /// <summary>
        /// Creates password hash
        /// </summary>
        /// <param name="password">Password</param>
        /// <param name="passwordHash">Password Hash</param>
        /// <param name="passwordSalt">Password Salt</param>

        public static void Create(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        /// <summary>
        /// Verifies Password Hash
        /// </summary>
        /// <param name="password">Password</param>
        /// <param name="storedHash">Store Hash</param>
        /// <param name="storedSalt">Store Salt</param>
        /// <returns></returns>
        public static bool Verify(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}
