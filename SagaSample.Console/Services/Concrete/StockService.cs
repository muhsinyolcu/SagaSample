using SagaSample.Console.Services.Abstract;

namespace SagaSample.Console.Services.Concrete;

public class StockService : IStockService
{
    public async Task<(bool isSuccess, string message)> ReserveStock(Guid orderId)
    {
        string message = $"[StockService] Stock reserved for Order: {orderId}";
        // Simulate stock check and reservation
        return (true, message);
    }

    public async Task<(bool isSuccess, string message)> ReleaseStock(Guid orderId)
    {
        string message = $"[StockService] Stock released for Order: {orderId}";
        // Simulate releasing reserved stock
        return (true, message);
    }
}

