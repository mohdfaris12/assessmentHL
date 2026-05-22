using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyAppAssessment.Data;
using MyAppAssessment.Model;

namespace MyAppAssessment.Pages.Customers;

[Authorize]
public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context) => _context = context;

    public IList<Customer> Customers { get; set; } = [];

    public async Task OnGetAsync()
    {
        Customers = await _context.Customers
            .AsNoTracking()
            .OrderBy(c => c.Name)
            .ToListAsync();
    }
}