namespace LojaVirtual.Domain.Notifications;

public sealed class Notification
{
    public required string Key { get; set; }
    public required string Message { get; set; }
}