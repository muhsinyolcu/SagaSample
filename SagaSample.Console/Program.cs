using SagaSample.Console.Orchestrators;
using SagaSample.Console.Services.Concrete;

// Instantiate dependencies
var stockService = new StockService();
var paymentService = new PaymentService();
var orderService = new OrderService();

var sagaOrchestrator = new OrderSagaOrchestrator(stockService, paymentService, orderService);

// Start the order process
var orderId = Guid.NewGuid();
var result = await sagaOrchestrator.ProcessOrderAsync(orderId);

Console.WriteLine(result ? "Order Processed Successfully!" : "Order Processing Failed.");