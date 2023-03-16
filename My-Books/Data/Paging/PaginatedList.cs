﻿namespace My_Books.Data.Paging
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPage { get; private set; }
        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPage = (int)Math.Ceiling(count / (double)pageSize);

            this.AddRange(items);
        }

        public bool hasNextPage
        {
            get
            {
                return PageIndex > 1;
            }
        }
        public bool HasNextpage
        {
            get
            {
                return PageIndex < TotalPage;
            }
        }

        public static PaginatedList<T> Create(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = source.Count();
            var item = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return new PaginatedList<T>(item, count, pageIndex, pageSize);
        }

    }
}
