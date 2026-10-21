
using System;
using System.Collections.Generic;
using System.Linq;

namespace OopHomework1.Models;

public class UserProfile
{
    public User User { get; }
    public List<Contact> Contacts { get; } = new();

    public UserProfile(User user)
    {
        User = user ?? throw new ArgumentNullException(nameof(user));
    }

    public void AddContact(Contact contact)
    {
        if (contact == null)
        {
            throw new ArgumentNullException(nameof(contact));
        }

        if (Contacts.Any(c => c.Id == contact.Id))
        {
            throw new ArgumentException(
                "Контакт с таким ID уже существует.");
        }

        Contacts.Add(contact);
    }

    public bool UpdateContact(int contactId, string newValue)
    {
        if (string.IsNullOrWhiteSpace(newValue))
        {
            return false;
        }

        Contact? contact =
            Contacts.FirstOrDefault(c => c.Id == contactId);

        if (contact == null)
        {
            return false;
        }

        contact.UpdateValue(newValue);
        return true;
    }

    // Деконструктор для получения краткой статистики профиля
    public void Deconstruct(
        out string fullName,
        out int contactCount)
    {
        fullName = User.FullName;
        contactCount = Contacts.Count;
    }
}
