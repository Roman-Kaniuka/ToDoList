using System.Linq.Expressions;

namespace ToDoListDomain.Extenstions;

//TODO: #28 Додаємо розширяючий метод для колекції "IQueryable" для роботи з фільтрами
public static class QueryExtenstion
{
    public static IQueryable<T> WhereIf<T>(this IQueryable<T> source, bool condition,
        Expression<Func<T, bool>> predicate)
    {
        if (condition)
            return source.Where(predicate);
        return source;
    }
}