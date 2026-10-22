
namespace OopHomework1.Models;

public class Contact
{
    public int Id { get; }
    public int ChannelId { get; }
    public string Value { get; private set; }

    public Contact(int id, int channelId, string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException(
                "Значение контакта не может быть пустым.",
                nameof(value));
        }

        Id = id;
        ChannelId = channelId;
        Value = value;
    }

    public void UpdateValue(string newValue)
    {
        if (string.IsNullOrWhiteSpace(newValue))
        {
            throw new ArgumentException(
                "Новое значение контакта не может быть пустым.",
                nameof(newValue));
        }

        Value = newValue;
    }
}
