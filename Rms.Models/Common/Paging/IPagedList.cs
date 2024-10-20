using System;
namespace Rms.Models.Common.Paging
{
    public interface IPagedList
    {
        public int CurrentPage { get;}
        public int TotalPages { get;}
        public int PageSize { get; }
        public int TotalCount { get;}
        public bool HasPrevious { get; }
        public bool HasNext { get; }
        public int StartCount { get; }
        public string NextLink { get; set; }
        public string PreviousLink { get; set; }

    }
}

