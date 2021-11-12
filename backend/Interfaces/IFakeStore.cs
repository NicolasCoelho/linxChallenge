using backend.Models;

namespace backend.Interfaces
{
    public interface IFakeStore
    {
        string BaseUrl {get;}
        Task AddProduct(Products product);
        Task UpdateProduct(int id, Products product);
        Task DeleteProduct(int id);
    }
}