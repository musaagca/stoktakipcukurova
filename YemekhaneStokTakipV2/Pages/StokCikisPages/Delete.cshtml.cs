using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using YemekhaneStokTakipV2.Models;
using YemekhaneStokTakipV2.Data;

namespace YemekhaneStokTakipV2.Pages.StokCikisPages;

public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DeleteModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public StokCikis StokCikis { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var stokcikis = await _context.StokCikis
            .FirstOrDefaultAsync(m => m.StokCikisId == id);

        if (stokcikis == null)
        {
            return NotFound();
        }

        StokCikis = stokcikis;

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var stokcikis = await _context.StokCikis.FindAsync(id);

        if (stokcikis != null)
        {
            StokCikis = stokcikis;
            _context.StokCikis.Remove(StokCikis);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}