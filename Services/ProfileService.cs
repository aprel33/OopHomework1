using System;
using System.Collections.Generic;
using System.Text;


using System;
using System.Collections.Generic;
using System.Linq;
using OopHomework1.Models;

namespace OopHomework1.Services;

public class ProfileService
{
    private readonly List<UserProfile> _profiles = new();
    private readonly List<CommunicationChannel> _channels = new();

    // Регистрация канала связи
    public bool RegisterChannel(CommunicationChannel channel)
    {
        if (channel == null)
        {
            return false;
        }

        if (_channels.Any(c => c.Id == channel.Id))
        {
            return false;
        }

        _channels.Add(channel);
        return true;
    }

    // Создание профиля пользователя
    public UserProfile? CreateProfile(User user)
    {
        if (user == null)
        {
            return null;
        }

        if (_profiles.Any(p => p.User.Id == user.Id))
        {
            return null;
        }

        UserProfile profile = new UserProfile(user);
        _profiles.Add(profile);

        return profile;
    }

    // Добавление контакта в профиль
    public bool AddContact(int userId, Contact contact)
    {
        if (contact == null)
        {
            return false;
        }

        UserProfile? profile =
            _profiles.FirstOrDefault(p => p.User.Id == userId);

        if (profile == null)
        {
            return false;
        }

        bool channelExists =
            _channels.Any(c => c.Id == contact.ChannelId);

        if (!channelExists)
        {
            return false;
        }

        bool contactExists =
            profile.Contacts.Any(c => c.Id == contact.Id);

        if (contactExists)
        {
            return false;
        }

        profile.AddContact(contact);
        return true;
    }

    // Изменение контакта
    public bool UpdateContact(
        int userId,
        int contactId,
        string newValue)
    {
        UserProfile? profile =
            _profiles.FirstOrDefault(p => p.User.Id == userId);

        if (profile == null)
        {
            return false;
        }

        return profile.UpdateContact(contactId, newValue);
    }

    // Получение статистики профиля
    public void ShowStatistics(int userId)
    {
        UserProfile? profile =
            _profiles.FirstOrDefault(p => p.User.Id == userId);

        if (profile == null)
        {
            Console.WriteLine("Профиль не найден.");
            return;
        }

        var (fullName, contactCount) = profile;

        Console.WriteLine();
        Console.WriteLine("=== Статистика профиля ===");
        Console.WriteLine($"Пользователь: {fullName}");
        Console.WriteLine($"Количество контактов: {contactCount}");
        Console.WriteLine("Контакты:");

        foreach (Contact contact in profile.Contacts)
        {
            CommunicationChannel? channel =
                _channels.FirstOrDefault(
                    c => c.Id == contact.ChannelId);

            string channelName =
                channel?.Name ?? "Неизвестный канал";

            Console.WriteLine(
                $"- {channelName}: {contact.Value}");
        }
    }
}
