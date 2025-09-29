using BLL.IServices;

namespace WebMVC.BackgroundWorker
{
    public class BackgroundServiceWorker : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public BackgroundServiceWorker(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _scopeFactory.CreateScope())
                {
                    var orderService = scope.ServiceProvider.GetRequiredService<IOrderService>();
                    var testDriveService = scope.ServiceProvider.GetRequiredService<ITestDriveAppointmentService>();

                    await orderService.CancelExpiredOrders();
                    await testDriveService.CheckAppointmentStatus();
                }

                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }
    }
}
