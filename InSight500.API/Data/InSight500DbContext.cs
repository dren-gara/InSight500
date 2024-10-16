using Microsoft.EntityFrameworkCore;

namespace InSight500.API.Data
{
    public class InSight500DbContext : DbContext
    {
        public InSight500DbContext(DbContextOptions<InSight500DbContext> options) : base(options) { }
        public DbSet<StockPrice> StockPrices { get; set; }
    }
    public class StockPrice
    {
        public int Id { get; set; }
        public required string Symbol { get; set; }
        public decimal OpenPrice { get; set; }
        public decimal ClosePrice { get; set; }
        public decimal HighPrice { get; set; }
        public decimal LowPrice { get; set; }
        public long Volume { get; set; }
        public DateTime Date { get; set; }
    }
}