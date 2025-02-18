using Microsoft.EntityFrameworkCore;

namespace InSight500.API.Data
{
    public class InSight500DbContext : DbContext
    {
        public InSight500DbContext(DbContextOptions<InSight500DbContext> options) : base(options) { }

        public DbSet<IncomeStatement> IncomeStatements { get; set; }
    }

    public class IncomeStatement
    {
        public int Id { get; set; }
        public required string Symbol { get; set; }
        public DateTime FiscalDateEnding { get; set; }
        public required string ReportedCurrency { get; set; }
        public decimal GrossProfit { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal OperatingIncome { get; set; }
        public decimal NetIncome { get; set; }
    }
}