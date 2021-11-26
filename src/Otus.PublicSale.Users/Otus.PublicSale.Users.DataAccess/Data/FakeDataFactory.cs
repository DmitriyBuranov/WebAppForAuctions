using Otus.PublicSale.Users.Core.Domain;
using System.Collections.Generic;

namespace Otus.PublicSale.Users.DataAccess.Data
{
    /// <summary>
    /// Fake Data Factory
    /// </summary>
    public static class FakeDataFactory
    {
        /// <summary>
        /// Default users
        /// </summary>
        public static List<User> Users
        {
            get
            {
                byte[] passwordHash, passwordSalt;
                PasswordHash.Create("1qaz@WSX", out passwordHash, out passwordSalt);

                return new List<User>()
                {
                    new User()
                    {
                        Id = 1,
                        FirstName = "Jon",
                        LastName = "Admin",
                        Username = "admin@admin.com",
                        PasswordHash = passwordHash,
                        PasswordSalt = passwordSalt,
                        Admin = true
                    },

                    new User()
                    {
                        Id = 2,
                        FirstName = "Alice",
                        LastName = "Smith",
                        Username = "alice@alice.com",
                        PasswordHash = passwordHash,
                        PasswordSalt = passwordSalt,
                        Admin = false
                    },

                    new User()
                    {   
                        Id = 3,
                        FirstName = "Bob",
                        LastName = "Smith",
                        Username = "bob@bob.com",
                        PasswordHash = passwordHash,
                        PasswordSalt = passwordSalt,
                        Admin = false
                    }
                };
            }
        }
    }
}
