using System.Collections.Generic;

namespace AdvAnalyzer.WebApi.Helpers
{
    public class PagedList<T>
    {
        public int Count { get; set; }
        public IEnumerable<T> Data { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
    }
}
