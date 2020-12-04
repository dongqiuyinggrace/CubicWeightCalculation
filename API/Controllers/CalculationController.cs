using System.Threading.Tasks;
using API.Products;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculationController : ControllerBase
    {
        private readonly IProductProcessor _processor;

        public CalculationController(IProductProcessor processor)
        {
            _processor = processor;
        }

        [HttpGet]
        public async Task<IActionResult> GetCalculationResult()
        {
            var result = await _processor.CalcAveCubicWeightAsync();
            return Ok(result);
        }
    }
}