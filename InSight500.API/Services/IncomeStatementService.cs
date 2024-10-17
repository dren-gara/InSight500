using InSight500.API.Data;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
public class IncomeStatementService
{
    private readonly string _apiKey = "ZCKVQCW5EW8KBUKJ";

    public async Task<List<IncomeStatement>> GetIncomeStatement(string symbol)
    {
        var url = $"https://www.alphavantage.co/query?function=INCOME_STATEMENT&symbol={symbol}&apikey={_apiKey}";
        using var client = new HttpClient();
        var response = await client.GetStringAsync(url);

        var incomeStatementResponse = JsonConvert.DeserializeObject<IncomeStatementResponse>(response);

        if (incomeStatementResponse?.AnnualReports == null)
        {
            return new List<IncomeStatement>();
        }

        return incomeStatementResponse.AnnualReports.Select(r => new IncomeStatement
        {
            Symbol = symbol,
            FiscalDateEnding = DateTime.SpecifyKind(DateTime.Parse(r.FiscalDateEnding), DateTimeKind.Utc), 
            ReportedCurrency = r.ReportedCurrency,
            GrossProfit = decimal.Parse(r.GrossProfit),
            TotalRevenue = decimal.Parse(r.TotalRevenue),
            OperatingIncome = decimal.Parse(r.OperatingIncome),
            NetIncome = decimal.Parse(r.NetIncome)
        }).ToList();
    }
}

public class IncomeStatementResponse
{
    [JsonProperty("annualReports")]
    public List<IncomeStatementData>? AnnualReports { get; set; }
}

public class IncomeStatementData
{
    public required string FiscalDateEnding { get; set; }
    public required string ReportedCurrency { get; set; }
    public required string GrossProfit { get; set; }
    public required string TotalRevenue { get; set; }
    public required string OperatingIncome { get; set; }
    public required string NetIncome { get; set; }
}