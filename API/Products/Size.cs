
namespace API.Products
{
    public class Size
    {
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public decimal Length { get; set; }

        public decimal GetVolume()
        {
            return Width/100 * Height/100 * Length/100;
        }
    }
}
