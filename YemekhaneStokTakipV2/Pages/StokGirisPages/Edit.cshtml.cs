using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using YemekhaneStokTakipV2.Data;
using YemekhaneStokTakipV2.Models;

namespace YemekhaneStokTakipV2.Pages.StokGirisPages;

public class EditModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public EditModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public SelectList UrunListesi { get; set; } = default!;
    public SelectList TedarikciListesi { get; set; } = default!;

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

        UrunListesi = new SelectList(_context.Urunler, "UrunId", "UrunAdi", StokGiris.UrunId);
        TedarikciListesi = new SelectList(_context.Tedarikciler, "TedarikciId", "FirmaAdi", StokGiris.TedarikciId);

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        UrunListesi = new SelectList(_context.Urunler, "UrunId", "UrunAdi", StokGiris.UrunId);
        TedarikciListesi = new SelectList(_context.Tedarikciler, "TedarikciId", "FirmaAdi", StokGiris.TedarikciId);

        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(StokGiris).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!StokGirisExists(StokGiris.StokGirisId))
            {
                return NotFound();
            }

            throw;
        }

        return RedirectToPage("./Index");
    }

    private bool StokGirisExists(int id)
    {
        return _context.StokGiris.Any(e => e.StokGirisId == id);
    }
}