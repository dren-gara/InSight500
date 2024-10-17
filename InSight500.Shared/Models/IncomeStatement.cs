namespace InSight500.Shared.Models
{
    public class IncomeStatement
    {
        public int Id { get; set; }
        public required string Symbol { get; set; }
        public DateTime FiscalDateEnding { get; set; }
        public string? ReportedCurrency { get; set; }
        public decimal GrossProfit { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal OperatingIncome { get; set; }
        public decimal NetIncome { get; set; }
    }
}