using SagaSample.Console.Services.Abstract;

namespace SagaSample.Console.Services.Concrete;

public class OrderService : IOrderService
{
    public async Task<(bool isSuccess, string message)> CompleteOrder(Guid orderId)
    {
        string message = $"[OrderService] Order completed: {orderId}";
        // Mark the order status as "completed"
        return (true, message);
    }

    public async Task<(bool isSuccess, string message)> FailOrder(Guid orderId, string reason)
    {
        string message = $"[OrderService] Order failed: {orderId}. Reason: {reason}";
        // Mark the order status as "failed"
        return (true, message);
    }
}