using System.Threading.Tasks;

namespace API.Products
{
    public interface IProductProcessor
    {
        Task<decimal> CalcAveCubicWeightAsync();
    }
}