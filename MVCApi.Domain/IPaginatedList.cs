using System.Collections.Generic;

namespace MVCApi.Domain
{
    public interface IPaginatedList<T> : IList<T>
    {
        int PageIndex { get; }
        int PageSize { get; }
        int TotalPages { get; }
        bool HasPreviousPage { get; }
        bool HasNextPage { get; }
    }
}