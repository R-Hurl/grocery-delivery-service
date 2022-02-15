namespace PendingOrdersService.Models
{
    public static class OrderStatus
    {
        public static string Pending { get; } = "P";
        public static string Processed { get; } = "PR";
        public static string Delivered { get; } = "D";
    }
}