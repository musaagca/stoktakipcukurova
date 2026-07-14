using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using YemekhaneStokTakipV2.Models;
using YemekhaneStokTakipV2.Data;

namespace YemekhaneStokTakipV2.Pages.StokGirisPages;

public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DeleteModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public StokGiris StokGiris { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var stokgiris = await _context.StokGiris
            .FirstOrDefaultAsync(m => m.StokGirisId == id);

        if (stokgiris == null)
        {
            return NotFound();
        }

        StokGiris = stokgiris;

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var stokgiris = await _context.StokGiris.FindAsync(id);

        if (stokgiris != null)
        {
            StokGiris = stokgiris;
            _context.StokGiris.Remove(StokGiris);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}