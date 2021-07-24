namespace Eshop.DAL.Enums
{
    public enum OrderStatus
    {
        New,
        CanceledByAdmin,
        PaymentReceived,
        Sent,
        Received,
        Complete,
        CanceledByUser
    }
}