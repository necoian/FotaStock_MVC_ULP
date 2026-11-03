namespace FotaStock.Web.Entities;


public class PaginatedList<TEntity>(List<TEntity> items, int pageIndex, int totalPages)
{
    
    public List<TEntity> Items {get;set;} = items;
    public int PageIndex {get;} = pageIndex;
    public int TotalPages {get;} = totalPages;

    public bool HasPreviousPage => PageIndex > 1;
    public bool HasNextPage => PageIndex < TotalPages;

}