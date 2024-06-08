using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestsBuilder.Domain.Common.Models;
using TestsBuilder.Domain.User.ValueObjects;

namespace TestsBuilder.Domain.User
{
    public sealed class User : AggregateRoot<UserId, Guid>
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        private User(
            UserId id,
            string firstName,
            string lastName,
            string email,
            string password)
            : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }

        public static User Create(
            string firstName,
            string lastName,
            string email,
            string password,
            bool isHost = false)
        {
            return new(
                UserId.CreateUnique(),
                firstName,
                lastName,
                email,
                password);
        }
        private User() : base(UserId.CreateUnique())
        {
        }
    }

}
