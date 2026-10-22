using System;
using System.Collections.Generic;
using System.Text;

namespace OopHomework1.Models;

public class User
{
    public int Id { get; }
    public string FullName { get; }
    public string Login { get; }
    public string PasswordHash { get; }

    public User(
        int id,
        string fullName,
        string login,
        string passwordHash)
    {
        if (id <= 0)
            throw new ArgumentOutOfRangeException(
                nameof(id), "ID должен быть положительным.");

        if (string.IsNullOrWhiteSpace(fullName))
            throw new ArgumentException(
                "ФИО не может быть пустым.", nameof(fullName));

        if (string.IsNullOrWhiteSpace(login))
            throw new ArgumentException(
                "Логин не может быть пустым.", nameof(login));

        if (string.IsNullOrWhiteSpace(passwordHash))
            throw new ArgumentException(
                "Хэш пароля не может быть пустым.", nameof(passwordHash));

        Id = id;
        FullName = fullName.Trim();
        Login = login.Trim();
        PasswordHash = passwordHash;
    }
}


