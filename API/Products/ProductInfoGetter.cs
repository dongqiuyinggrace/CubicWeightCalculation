using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace API.Products
{
    public class ProductInfoGetter : IProductInfoGetter
    {
        private const string BASE_URL = "http://wp8m3he1wt.s3-website-ap-southeast-2.amazonaws.com";
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductInfoGetter(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ProductResult> GetProductResultAsync(string productUrl)
        {
            var _httpClient = _httpClientFactory.CreateClient();
            var response = await _httpClient.GetAsync(BASE_URL + productUrl);
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ProductResult>(result);
        }
    }
}