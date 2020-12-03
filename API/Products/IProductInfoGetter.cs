using System.Threading.Tasks;

namespace API.Products
{
    public interface IProductInfoGetter
    {
        Task<ProductResult> GetProductResult(string url);
    }
}