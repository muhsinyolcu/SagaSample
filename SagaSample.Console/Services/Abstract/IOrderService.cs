namespace SagaSample.Console.Services.Abstract;
public interface IOrderService
{
    Task<(bool isSuccess, string message)> CompleteOrder(Guid orderId);
    Task<(bool isSuccess, string message)> FailOrder(Guid orderId, string reason);
}
