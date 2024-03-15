using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        Task<Products> GetProductByIdAysnc(int id);
        Task<IReadOnlyList<Products>> GetProductsAsync();

        Task<IReadOnlyList<ProductBrand>> GetProductBrandAsync();

        Task<IReadOnlyList<ProductType>> GetProductTypeAsync();
    }
}