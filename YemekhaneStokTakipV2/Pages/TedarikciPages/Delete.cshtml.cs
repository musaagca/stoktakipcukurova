using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using YemekhaneStokTakipV2.Models;
using YemekhaneStokTakipV2.Data;

namespace YemekhaneStokTakipV2.Pages.TedarikciPages;

public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DeleteModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Tedarikci Tedarikci { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var tedarikci = await _context.Tedarikciler
            .FirstOrDefaultAsync(m => m.TedarikciId == id);

        if (tedarikci == null)
        {
            return NotFound();
        }

        Tedarikci = tedarikci;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var tedarikci = await _context.Tedarikciler.FindAsync(id);

        if (tedarikci != null)
        {
            _context.Tedarikciler.Remove(tedarikci);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}