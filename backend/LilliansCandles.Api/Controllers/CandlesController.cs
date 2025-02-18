using Microsoft.AspNetCore.Mvc;
using LilliansCandles.Api.Models;

namespace LilliansCandles.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CandlesController : ControllerBase
    {


        public record Candle(int Id, string Name, string Scent, decimal Price, int Stock);

        /// <summary>
        /// Get all available candles
        /// </summary>
        /// <returns>List of candles</returns>
        /// 
        [HttpGet]
        [ProducesResponseType(typeof(List<Candle>), 200)]
        public ActionResult<List<Candle>> GetCandles()
        {
            var candles = new List<Candle>
            {
                new(1, "Lavender BLiss", "Lavender", 14.99m, 3),
                new(2, "Vanilla Dream", "Vanilla", 12.99m, 2),
                new(3, "Ocean Breeze", "Sea Salt & Jasmine", 16.99m, 2),
            };
            return Ok(candles);
        }

        /// <summary> 
        /// Get a single candle by ID.
        /// </summary>
        /// <param name="id">The ID of the selected candle</param>
        /// <returns>The requested candle</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Candle), 200)]
        [ProducesResponseType(404)]
        public ActionResult<Candle> GetCandleById(int id)
        { 
            var candle = new Candle(id, "Test Candle","Test Scent",9.99m, 2);

            if (id <= 0) return NotFound();

            return Ok(candle);
        }
    }
}