using System.Threading.Tasks;

namespace API.Products
{
    public interface IProductInfoGetter
    {
        Task<ProductResult> GetProductResultAsync(string url);
    }
}