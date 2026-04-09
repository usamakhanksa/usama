using Application.Common;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class EfRepository<T> : IRepository<T> where T : class
{
    private readonly AppDbContext _db;
    public EfRepository(AppDbContext db) => _db = db;

    public Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => _db.Set<T>().FindAsync([id], cancellationToken).AsTask();

    public IQueryable<T> Query() => _db.Set<T>().AsQueryable();

    public Task AddAsync(T entity, CancellationToken cancellationToken = default)
        => _db.Set<T>().AddAsync(entity, cancellationToken).AsTask();

    public void Update(T entity) => _db.Set<T>().Update(entity);

    public void Remove(T entity) => _db.Set<T>().Remove(entity);
}

public class EfUnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _db;
    public EfUnitOfWork(AppDbContext db) => _db = db;
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => _db.SaveChangesAsync(cancellationToken);
}
