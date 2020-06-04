namespace Domain.Entities
{
    public enum OrderStatus
    {
        Open,
        Gathering,
        WaitingForDelivery,
        Delivering,
        Delivered,
        Cancel
    }
}