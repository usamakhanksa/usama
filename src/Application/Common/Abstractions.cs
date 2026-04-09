namespace Application.Common;

public interface IRepository<T> where T : class
{
    Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    IQueryable<T> Query();
    Task AddAsync(T entity, CancellationToken cancellationToken = default);
    void Update(T entity);
    void Remove(T entity);
}

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}

public interface ITenantContext
{
    Guid TenantId { get; }
    string? TenantCode { get; }
}

public interface IQueueService
{
    Task EnqueueAsync<TJob>(TJob payload, string queueName, CancellationToken cancellationToken = default);
}

public interface IBackgroundJob
{
    Task ExecuteAsync(CancellationToken cancellationToken = default);
}

public interface IEmailQueue
{
    Task EnqueueEmailAsync(string to, string subject, string body, CancellationToken cancellationToken = default);
}

public interface IFileStorageService
{
    Task<string> UploadAsync(Stream stream, string path, string contentType, CancellationToken cancellationToken = default);
    Task DeleteAsync(string path, CancellationToken cancellationToken = default);
    string GetUrl(string path, TimeSpan? ttl = null);
}

public interface ICurrencyConverter
{
    Task<decimal> ConvertAsync(decimal amount, string fromCurrency, string toCurrency, DateTime? asOf = null, CancellationToken cancellationToken = default);
}
