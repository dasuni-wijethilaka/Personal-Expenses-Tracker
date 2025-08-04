using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExpenseTrackerAPI.Data;
using ExpenseTrackerAPI.Models;
using ExpenseTrackerAPI.DTOs;

[ApiController]
[Route("api/[controller]")]
public class ExpensesController : ControllerBase
{
    private readonly ExpenseContext _context;

    public ExpensesController(ExpenseContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ExpenseResponseDto>>> GetExpenses()
    {
        var expenses = await _context.Expenses
            .Select(e => new ExpenseResponseDto
            {
                Id = e.Id,
                Description = e.Description,
                Amount = e.Amount,
                Date = e.Date,
                Category = e.Category
            })
            .ToListAsync();

        return Ok(expenses);
    }

    [HttpPost]
    public async Task<ActionResult<ExpenseResponseDto>> CreateExpense(CreateExpenseDto dto)
    {
        var expense = new Expense
        {
            Description = dto.Description,
            Amount = dto.Amount,
            Date = dto.Date,
            Category = dto.Category
        };

        _context.Expenses.Add(expense);
        await _context.SaveChangesAsync();

        var response = new ExpenseResponseDto
        {
            Id = expense.Id,
            Description = expense.Description,
            Amount = expense.Amount,
            Date = expense.Date,
            Category = expense.Category
        };

        return CreatedAtAction(nameof(GetExpense), new { id = expense.Id }, response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ExpenseResponseDto>> GetExpense(int id)
    {
        var expense = await _context.Expenses.FindAsync(id);
        if (expense == null) return NotFound();

        var response = new ExpenseResponseDto
        {
            Id = expense.Id,
            Description = expense.Description,
            Amount = expense.Amount,
            Date = expense.Date,
            Category = expense.Category
        };

        return Ok(response);
    }
}