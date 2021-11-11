using backend.Models;

namespace backend.Interfaces
{
    public interface IProductsPagination
    {
        int totalPages {get; set;}
        IEnumerable<Products> items {get; set;}
    }
}