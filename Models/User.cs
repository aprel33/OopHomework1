using System;
using System.Collections.Generic;
using System.Text;


namespace OopHomework1.Models;

public class User
{
    private int Id;
    
    public int Id { 
        get{
            return Id;
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
        Id = id;
        FullName = fullName;
        Login = login;
        PasswordHash = passwordHash;
    }
}
