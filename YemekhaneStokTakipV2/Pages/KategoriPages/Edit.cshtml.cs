using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using YemekhaneStokTakipV2.Data;
using YemekhaneStokTakipV2.Models;

namespace YemekhaneStokTakipV2.Pages.KategoriPages;

public class EditModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public EditModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Kategori Kategori { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var kategori = await _context.Kategoriler
            .FirstOrDefaultAsync(m => m.KategoriId == id);

        if (kategori == null)
        {
            return NotFound();
        }

        Kategori = kategori;

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(Kategori).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!KategoriExists(Kategori.KategoriId))
            {
                return NotFound();
            }

            throw;
        }

        return RedirectToPage("./Index");
    }

    private bool KategoriExists(int id)
    {
        return _context.Kategoriler.Any(e => e.KategoriId == id);
    }
}