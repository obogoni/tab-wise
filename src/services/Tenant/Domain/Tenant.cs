using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;
using Framework.Domain;

namespace Tenant.Domain
{
    public class Tenant : Entity<Guid>, IAggregateRoot
    {
        public string UserUid { get; set; }

        public string Name { get; set; }

        public PhoneNumber PhoneNumber { get; set; }

        public string Email { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool IsActive { get; set; }

        public static class Errors
        {
            public static string InvalidEmail => "Email is not valid";
            public static string InvalidName => "Name is not valid";
        }

    }
}
