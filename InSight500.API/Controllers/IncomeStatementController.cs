using InSight500.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/income-statements")]
public class IncomeStatementController : ControllerBase
{
    private readonly InSight500DbContext _context;
    private readonly IncomeStatementService _incomeStatementService;

    public IncomeStatementController(InSight500DbContext context, IncomeStatementService incomeStatementService)
    {
        _context = context;
        _incomeStatementService = incomeStatementService;
    }

    [HttpGet]
    public async Task<IActionResult> GetIncomeStatements([FromQuery] string symbol)
    {
        if (string.IsNullOrEmpty(symbol))
        {
            return BadRequest("Symbol is required.");
        }

        symbol = symbol.ToUpper(); 

        var incomeStatements = await _context.IncomeStatements
                                             .Where(i => i.Symbol == symbol)
                                             .ToListAsync();

        if (!incomeStatements.Any())
        {
            try
            {
                incomeStatements = await _incomeStatementService.GetIncomeStatement(symbol);
                
                if (incomeStatements.Any())
                {
                    await _context.IncomeStatements.AddRangeAsync(incomeStatements);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return NotFound($"No income statements found for symbol {symbol} from Alpha Vantage.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error fetching data from Alpha Vantage: {ex.Message}");
            }
        }

        return Ok(incomeStatements);
    }
}