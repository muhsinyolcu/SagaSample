namespace SagaSample.Console.Services.Abstract;
public interface IStockService
{
    Task<(bool isSuccess, string message)> ReserveStock(Guid orderId);
    Task<(bool isSuccess, string message)> ReleaseStock(Guid orderId);
}