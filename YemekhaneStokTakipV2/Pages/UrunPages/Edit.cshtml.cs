using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using YemekhaneStokTakipV2.Data;
using YemekhaneStokTakipV2.Models;

namespace YemekhaneStokTakipV2.Pages.UrunPages;

public class EditModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public EditModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Urun Urun { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var urun = await _context.Urunler
            .FirstOrDefaultAsync(m => m.UrunId == id);

        if (urun == null)
        {
            return NotFound();
        }

        Urun = urun;

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(Urun).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!UrunExists(Urun.UrunId))
            {
                return NotFound();
            }

            throw;
        }

        return RedirectToPage("./Index");
    }

    private bool UrunExists(int id)
    {
        return _context.Urunler.Any(e => e.UrunId == id);
    }
}