using System;
using System.Collections.Generic;
using System.Text;


namespace OopHomework1.Models;

public class CommunicationChannel
{
    public int Id { get; }
    public string Name { get; }

    public CommunicationChannel(int id, string name)
    {
        Id = id;
        Name = name;
    }
}
