using GymCraftAPI.Domain.ValueObjects;

namespace GymCraftAPI.Domain.Entities;

public class User : EntityBase
{
    public Name Name { get; private set; }
    public Email Email { get; private set; }
    public string PasswordHash { get; private set; }

    public User(Name name, Email email, string passwordHash)
    {
        Name = name;
        Email = email;
        PasswordHash = passwordHash;
    }
}
