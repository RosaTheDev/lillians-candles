namespace LilliansCandles.Api.Models
{
    public class Candle
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Scent { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

    }
}
