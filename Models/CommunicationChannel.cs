using System;
using System.Collections.Generic;
using System.Text;


namespace OopHomework1.Models;

public class CommunicationChannel
{
    private int _id;
    private string _name;
    public int Id 
    {
        get { return _id; }
    }
    public string Name{
        get { return _name; }
    }

    public CommunicationChannel(int id, string name)
   {
        
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Имя канала связи не может быть пустым.", nameof(name));
        }

        _id = id;
        _name = name;
    }
    public override string ToString()
    {
        return $"Канал: {_name} (ID: {_id})";
    }
}
}
