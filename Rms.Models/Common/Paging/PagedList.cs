
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rms.Models.Common.Paging
{
    public class PagedList<TEntity> : List<TEntity>, IPagedList
    {
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }


        public int StartCount
        {
            get
            {
                return PageSize * (CurrentPage - 1);

            }
        }


        public bool HasPrevious
        {
            get
            {
                return (CurrentPage > 1);
            }
        }

        public bool HasNext
        {
            get
            {
                return (CurrentPage < TotalPages);

            }
        }

        public string? NextLink { get; set; }
        public string? PreviousLink { get; set; }

        public PagedList(List<TEntity> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            this.AddRange(items);

        }

        public static async Task<PagedList<TEntity>> CreateAsync(IQueryable<TEntity> source, int pageNumber, int pageSize, bool isPaginationDisabled = false)
        {
            var count = await source.CountAsync();

            if (isPaginationDisabled)
            {
                pageNumber = 0;
                pageSize = count;
            }
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PagedList<TEntity>(items, count, pageNumber, pageSize);
        }

        public static async Task<PagedList<TEntity>> CreateAsync(IQueryable<TEntity> source, PageParams pageParam)
        {
            var count = await source.CountAsync();
            int pageNumber = pageParam.PageNumber;
            int pageSize = pageParam.PageSize;
            if (pageParam.IsPaginationDisabled)
            {
                pageNumber = 0;
                pageSize = count;
            }
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PagedList<TEntity>(items, count, pageNumber, pageSize);
        }


        public static PagedList<TEntity> Create(List<TEntity> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return new PagedList<TEntity>(items, count, pageNumber, pageSize);
        }

        public static PagedList<TEntity> CreateRef(List<TEntity> source, ref int pageNumber, int pageSize, string selectedClientJobCode = "", string catalyzrPersonId = "", string skillId = "")
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return new PagedList<TEntity>(items, count, pageNumber, pageSize);
        }
    }
}
