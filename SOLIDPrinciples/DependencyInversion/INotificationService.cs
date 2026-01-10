namespace SOLIDPrinciples.DependencyInversion.Good
{
    /// <summary>
    /// Abstraction for notification services.
    /// High-level code depends on this, not on concrete notification implementations.
    /// </summary>
    public interface INotificationService
    {
        void SendOrderConfirmation(string recipientEmail, int orderId);
    }
}
