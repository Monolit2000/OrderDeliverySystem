using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class ScheduledTaskBasketCleanup : IHostedService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private Timer _timer;

    public ScheduledTaskBasketCleanup(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        var now = DateTime.Now;
        var nextRun = now.Date.AddDays(1).AddHours(17);
        var initialDelay = nextRun - now;

        _timer = new Timer(DoWork, null, initialDelay, TimeSpan.FromDays(1));
        return Task.CompletedTask;
    }

    private async void DoWork(object state)
    {
        using (var scope = _serviceScopeFactory.CreateScope())
        {
            var basketCleanupService = scope.ServiceProvider.GetRequiredService<BasketCleanupService>();
            await basketCleanupService.CleanUpOldItems(DateTime.Now);
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _timer?.Change(Timeout.Infinite, 0);
        return Task.CompletedTask;
    }

}
