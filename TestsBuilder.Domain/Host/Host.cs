using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestsBuilder.Domain.Host.ValueObjects;
using TestsBuilder.Domain.Common.Models;
using TestsBuilder.Domain.Test.ValueObjects;
using TestsBuilder.Domain.User.ValueObjects;
namespace TestsBuilder.Domain.Host
{
    public sealed class Host : AggregateRoot<HostId,Guid>
    {
        private readonly List<TestId> _testIds = new();

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string ProfileImage { get; private set; }
        public UserId UserId { get; private set; }

        public IReadOnlyList<TestId> TestIds => _testIds.AsReadOnly();

        private Host(
            HostId hostId,
            string firstName,
            string lastName,
            string profileImage,
            UserId userId)
            : base(hostId)
        {
            FirstName = firstName;
            LastName = lastName;
            ProfileImage = profileImage;
            UserId = userId;
        }

        private Host() { }

        public static Host Create(
            string firstName,
            string lastName,
            string profileImage,
            UserId userId)
        {
            return new(
                HostId.CreateUnique(),
                firstName,
                lastName,
                profileImage,
                userId);
        }
    }
}
