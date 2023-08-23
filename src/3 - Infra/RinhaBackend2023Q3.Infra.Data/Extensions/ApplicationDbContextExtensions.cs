using Microsoft.EntityFrameworkCore;
using RinhaBackend2023Q3.Infra.Data.Context;

namespace RinhaBackend2023Q3.Infra.Data.Extensions;

public static class ApplicationDbContextExtensions
{
    public static ICollection<T> GetAll<T>(this ApplicationDbContext context)
        where T : class
    {
        return context.Set<T>().ToList();
    }

    public static T? GetById<T>(this ApplicationDbContext context, Guid id)
        where T : class
    {
        return context.Set<T>().FirstOrDefault(x => EF.Property<Guid>(x, "Id") == id);
    }

    public static T? Add<T>(this ApplicationDbContext context, T entity)
        where T : class
    {
        context.Set<T>().Add(entity);
        return entity;
    }

    public static void Update<T>(this ApplicationDbContext context, T entity)
        where T : class
    {
        var existing = context.Set<T>().Find(entity);

        if (existing is null)
            return;

        context.Entry(existing!).CurrentValues.SetValues(entity);
    }

    public static void Remove<T>(this ApplicationDbContext context, T entity)
        where T : class
    {
        var existing = context.Set<T>().Find(entity);

        if (existing is null)
            return;

        context.Set<T>().Remove(entity);
    }
}
