using SagaSample.Console.Services.Abstract;

namespace SagaSample.Console.Orchestrators;
public class OrderSagaOrchestrator
{
    private readonly IStockService _stockService;
    private readonly IPaymentService _paymentService;
    private readonly IOrderService _orderService;

    public OrderSagaOrchestrator(IStockService stockService, IPaymentService paymentService, IOrderService orderService)
    {
        _stockService = stockService;
        _paymentService = paymentService;
        _orderService = orderService;
    }

    public async Task<bool> ProcessOrderAsync(Guid orderId)
    {
        try
        {
            // 1. Reserve stock
            (bool isStockReservSuccess, string stockReservMessage) = await _stockService.ReserveStock(orderId);
            if (!isStockReservSuccess)
            {
                await _orderService.FailOrder(orderId, $"Stock reservation failed. Message: {stockReservMessage}");
                return false;
            }

            // 2. Process payment
            (bool isPaymentProcessSuccess, string paymentProcessMessage)  = await _paymentService.ProcessPayment(orderId);
            if (!isPaymentProcessSuccess)
            {
                await _stockService.ReleaseStock(orderId); // Compensating action
                await _orderService.FailOrder(orderId, $"Payment processing failed. Message:{paymentProcessMessage}");
                return false;
            }

            // 3. Complete order
            await _orderService.CompleteOrder(orderId);
            return true;
        }
        catch (Exception ex)
        {
            // Handle rollback actions in case of unexpected errors
            await _stockService.ReleaseStock(orderId);
            await _orderService.FailOrder(orderId, $"Unexpected error: {ex.Message}");
            return false;
        }
    }
}
