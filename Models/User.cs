using System;
using System.Collections.Generic;
using System.Text;


namespace OopHomework1.Models;

public class User
{
    // Приватное поле с маленькой буквы
    private int id;

    // Публичное свойство с БОЛЬШОЙ буквы, которое запрашивал компилятор
    public int Id {
        get {
            return id;
        }
    }

    public string FullName { get; }
    public string Login { get; }
    public string PasswordHash { get; }

    public User(
        int id,
        string fullName,
        string login,
        string passwordHash)
    {
        // Присваиваем значение полю и свойствам
        this.id = id; 
        FullName = fullName;
        Login = login;
        PasswordHash = passwordHash;
    }
}

