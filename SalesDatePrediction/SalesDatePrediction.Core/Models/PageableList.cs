using PagedList;
using System.Diagnostics.CodeAnalysis;

namespace SalesDatePrediction.Core.Models
{
    [ExcludeFromCodeCoverage]
    public class PageableList<T>
    {
        public int totalElements { get; set; }
        public int page { get; set; }
        public int size { get; set; }
        public int totalPages { get; set; }
        public int totalContent { get; set; }
        public List<T> content { get; set; }

        public PageableList() { }

        public PageableList(IPagedList<T> pagedList)
        {
            totalElements = pagedList.TotalItemCount;
            page = pagedList.PageNumber;
            size = pagedList.PageSize;
            totalPages = pagedList.PageCount;
            totalContent = pagedList.Count;
            content = pagedList.ToList();
        }

        public PageableList(int totalElements, int page, int size, int totalPages, int totalContent, List<T> content)
        {
            this.totalElements = totalElements;
            this.page = page;
            this.size = size;
            this.totalPages = totalPages;
            this.totalContent = totalContent;
            this.content = content;
        }
    }
}
