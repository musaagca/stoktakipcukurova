using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using YemekhaneStokTakipV2.Data;
using YemekhaneStokTakipV2.Models;

namespace YemekhaneStokTakipV2.Pages.StokCikisPages;

public class EditModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public EditModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public SelectList UrunListesi { get; set; } = default!;

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

        UrunListesi = new SelectList(
            _context.Urunler,
            "UrunId",
            "UrunAdi",
            StokCikis.UrunId);

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        UrunListesi = new SelectList(
            _context.Urunler,
            "UrunId",
            "UrunAdi",
            StokCikis.UrunId);

        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(StokCikis).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!StokCikisExists(StokCikis.StokCikisId))
            {
                return NotFound();
            }

            throw;
        }

        return RedirectToPage("./Index");
    }

    private bool StokCikisExists(int id)
    {
        return _context.StokCikis.Any(e => e.StokCikisId == id);
    }
}