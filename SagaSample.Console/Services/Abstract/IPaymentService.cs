namespace SagaSample.Console.Services.Abstract;
public interface IPaymentService
{
    Task<(bool isSuccess, string message)> ProcessPayment(Guid orderId);
}
