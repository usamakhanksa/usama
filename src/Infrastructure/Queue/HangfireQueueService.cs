using Application.Common;

namespace Infrastructure.Queue;

public class HangfireQueueService : IQueueService, IEmailQueue
{
    public Task EnqueueAsync<TJob>(TJob payload, string queueName, CancellationToken cancellationToken = default)
    {
        // Replace with Hangfire/RabbitMQ adapter implementation.
        return Task.CompletedTask;
    }

    public Task EnqueueEmailAsync(string to, string subject, string body, CancellationToken cancellationToken = default)
    {
        // Replace with concrete email queue producer.
        return Task.CompletedTask;
    }
}
