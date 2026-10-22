
using System;
using OopHomework1.Models;
using OopHomework1.Services;

namespace OopHomework1;

internal class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        ProfileService service = new ProfileService();

        // 1. Регистрируем каналы связи
        CommunicationChannel email =
            new CommunicationChannel(1, "Электронная почта");

        CommunicationChannel telegram =
            new CommunicationChannel(2, "Telegram");

        service.RegisterChannel(email);
        service.RegisterChannel(telegram);

        // 2. Создаём пользователя
        User user = new User(
            1,
            "Григорий Оганесян",
            "greg",
            "example_hash");

        // 3. Создаём профиль
        UserProfile? profile = service.CreateProfile(user);

        if (profile == null)
        {
            Console.WriteLine("Не удалось создать профиль.");
            return;
        }

        Console.WriteLine("Профиль успешно создан.");

        // 4. Добавляем контакты
        bool emailAdded = service.AddContact(
            user.Id,
            new Contact(1, email.Id, "greg@gmail.com"));

        bool telegramAdded = service.AddContact(
            user.Id,
            new Contact(2, telegram.Id, "@greg"));

        Console.WriteLine(
            $"Электронная почта добавлена: {emailAdded}");

        Console.WriteLine(
            $"Telegram добавлен: {telegramAdded}");

        // 5. Изменяем контакт
        bool updated = service.UpdateContact(
            user.Id,
            2,
            "@ivan_new");

        Console.WriteLine(
            $"Контакт изменён: {updated}");

        // 6. Выводим статистику с деконструктором
        service.ShowStatistics(user.Id);

        // 7. Проверяем обработку ошибки
        bool invalidContactAdded = service.AddContact(
            user.Id,
            new Contact(3, 999, "unknown@example.com"));

        Console.WriteLine(
            $"\nДобавление контакта с неизвестным каналом: " +
            $"{invalidContactAdded}");

        Console.WriteLine("\nДемонстрация завершена.");
        Console.ReadKey();
    }
}
