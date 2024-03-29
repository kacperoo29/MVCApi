using System;
using System.Collections.Generic;
using MVCApi.Domain;

namespace MVCApi.Application
{
    public class PaginatedList<T> : IPaginatedList<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public IEnumerable<T> Items { get; private set; }

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize, int? totalPages = null)
        {
            PageIndex = pageIndex;
            TotalPages = totalPages ?? (int)Math.Ceiling(count / (double)pageSize);
            PageSize = pageSize;
            Items = items;
        }

        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }
    }
}