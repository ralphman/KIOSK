
// .NET Console App 예제 (.NET 6+)
// 필요한 NuGet: Microsoft.Extensions.DependencyInjection

using System;
using Microsoft.Extensions.DependencyInjection;

// 1. 로깅 서비스 인터페이스 및 구현체
public interface ILoggerService {
    void Log(string message);
}

public class ConsoleLoggerService : ILoggerService {
    public void Log(string message) {
        Console.WriteLine($"[LOG] {DateTime.Now}: {message}");
    }
}

// 2. 주문 처리 서비스 인터페이스 및 구현체
public interface IOrderService {
    void PlaceOrder(int productId, int quantity);
}

public class OrderService : IOrderService {
    private readonly ILoggerService _logger;

    public OrderService(ILoggerService logger) {
        _logger = logger;
    }

    public void PlaceOrder(int productId, int quantity) {
        _logger.Log($"주문 접수됨: 상품 ID = {productId}, 수량 = {quantity}");
        // 실제 비즈니스 로직은 DB 저장 등 추가
    }
}

// 3. 서비스 사용 예제
class Program1111 {
    static void Main111(string[] args) {
        var services = new ServiceCollection();

        // DI 등록
        services.AddSingleton<ILoggerService, ConsoleLoggerService>();
        services.AddTransient<IOrderService, OrderService>();

        var provider = services.BuildServiceProvider();

        // 서비스 사용
        var orderService = provider.GetService<IOrderService>();
        orderService.PlaceOrder(101, 5);
    }
}
