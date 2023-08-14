namespace Application.Comman.Models;

public class PaginatedList<T>
{
    public int PageIndex { get; private set; }
    public int TotalPage { get; private set; }

    public bool HasPreviousPage => PageIndex > 1;
    public bool HasNextPage => PageIndex < TotalPage;

    public List<T>? items { get;  set; } = new List<T>();
    public PaginatedList(List<T> Items, int Count, int PageSize, int PageIndex)
    {
        TotalPage = (int)Math.Ceiling(Count / (double)PageSize);
        this.PageIndex = PageIndex;
        this.items = Items;
    }

    public static PaginatedList<T> Create(List<T> collection, int pageSize, int pageIndex)
    {
        List<T>? items = null;
        int count = collection.Count;
        if (count > pageSize * pageIndex)
        {
            items = collection.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
        else
        {
            items = collection.Skip((pageIndex - 1) * pageSize).ToList();
        }

        return new PaginatedList<T>(items, count, pageSize, pageIndex);
    }
}
