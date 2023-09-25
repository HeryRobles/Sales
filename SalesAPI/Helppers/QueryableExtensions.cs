using SalesShared.DTOs;

namespace SalesAPI.Helppers
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Paginar<T>(this IQueryable<T> queryable,
            PaginacionDTO Paginacion)
        {
            return queryable
                .Skip((Paginacion.Page - 1) * Paginacion.RecordsNumber)
                .Take(Paginacion.RecordsNumber);
        }
    }
}
