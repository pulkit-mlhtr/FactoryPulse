using FactoryPulse.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPulse.Domain.Entities
{
    public class User(string name, string email, UserRole role)
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        public string Name { get; private set; } = name;

        public string Email { get; private set; } = email;

        public UserRole Role { get; private set; } = role;

        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    }
}
