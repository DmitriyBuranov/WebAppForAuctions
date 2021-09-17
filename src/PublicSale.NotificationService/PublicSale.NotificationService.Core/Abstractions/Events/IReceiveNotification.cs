using System;


namespace PublicSale.NotificationService.Core.Abstractions
{
    public interface IReceiveNotification
    {
        string Email { get; }

        string EmailFrom { get; }

        string Message { get; }

        string Subject { get; }

        string Status { get; }
    }
}
