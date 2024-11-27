using SagaSample.Console.Services.Abstract;

namespace SagaSample.Console.Services.Concrete;
public class PaymentService : IPaymentService
{
    public async Task<(bool isSuccess, string message)> ProcessPayment(Guid orderId)
    {
        string message = $"[PaymentService] Payment processed for Order: {orderId}";
        // Simulate payment processing
        return (true, message);
    }
}