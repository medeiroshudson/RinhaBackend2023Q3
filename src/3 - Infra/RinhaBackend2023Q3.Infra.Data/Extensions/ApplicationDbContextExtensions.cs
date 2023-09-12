using RinhaBackend2023Q3.Domain;
using Microsoft.EntityFrameworkCore;
using RinhaBackend2023Q3.Infra.Data.Context;
using RinhaBackend2023Q3.Domain.Interfaces;
using System.Linq.Expressions;
using System.Net;

namespace RinhaBackend2023Q3.Infra.Data.Extensions;

public static class ApplicationDbContextExtensions
{
    public static async Task<ICollection<T>> GetManyAsync<T>(
        this ApplicationDbContext context,
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        int? top = null,
        int? skip = null
    )
        where T : class, IAuditableEntity
    {
        IQueryable<T> query = context.Set<T>();

        if (filter is not null)
            query = query.Where(filter);

        if (orderBy is not null)
            query = orderBy(query);

        if (skip.HasValue)
            query = query.Skip(skip.Value);

        if (top.HasValue)
            query = query.Take(top.Value);

        return await query.ToListAsync();
    }

    public static async Task<ICollection<T>> GetAllAsync<T>(this ApplicationDbContext context)
        where T : class, IAuditableEntity
    {
        return await context.Set<T>().ToListAsync();
    }

    public static async Task<T?> GetByIdAsync<T>(this ApplicationDbContext context, Guid id)
        where T : class, IAuditableEntity
    {
        return await context.Set<T>().FindAsync(id);
    }

    public static async Task AddAsync<T>(this ApplicationDbContext context, T entity)
        where T : class, IAuditableEntity
    {
        await context.Set<T>().AddAsync(entity);
    }

    public static async Task UpdateAsync<T>(this ApplicationDbContext context, T entity)
        where T : class, IAuditableEntity
    {
        var existing =
            await context.Set<T>().FindAsync(entity.Id)
            ?? throw new NotFoundException(typeof(T).Name, entity.Id);

        // context.Entry(existing).CurrentValues.SetValues(entity);

        context.Entry(entity).State = EntityState.Modified;
    }

    public static async Task RemoveAsync<T>(this ApplicationDbContext context, Guid id)
        where T : class, IAuditableEntity
    {
        var existing =
            await context.Set<T>().FindAsync(id) ?? throw new NotFoundException(typeof(T).Name, id);

        context.Set<T>().Remove(existing);
    }
}
