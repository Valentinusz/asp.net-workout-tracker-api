namespace WorkoutTrackerServer.Pagination;

public class Page<T>
{
    public IEnumerable<T> Content { get; set; }
    public int TotalItems { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPages => (int)Math.Ceiling((double)TotalItems / PageSize);
    public bool HasPreviousPage => PageNumber > 1;
    public bool HasNextPage => PageNumber < TotalPages;

    public Page()
    {
        
    }
    
    public Page(IEnumerable<T> content, int count, int pageNumber, int pageSize)
    {
        Content = content;
        TotalItems = count;
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}