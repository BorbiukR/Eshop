namespace EShop.DAL.Models.Enums
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