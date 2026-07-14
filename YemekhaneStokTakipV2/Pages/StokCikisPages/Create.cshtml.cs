using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YemekhaneStokTakipV2.Data;
using YemekhaneStokTakipV2.Models;

namespace YemekhaneStokTakipV2.Pages.StokCikisPages;

public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public CreateModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public SelectList UrunListesi { get; set; } = default!;

    [BindProperty]
    public StokCikis StokCikis { get; set; } = default!;

    public IActionResult OnGet()
    {
        UrunListesi = new SelectList(_context.Urunler, "UrunId", "UrunAdi");
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        UrunListesi = new SelectList(_context.Urunler, "UrunId", "UrunAdi");

        if (!ModelState.IsValid)
        {
            return Page();
        }

        var urun = await _context.Urunler.FindAsync(StokCikis.UrunId);

        if (urun == null)
        {
            return NotFound();
        }

        if (urun.MevcutStok < StokCikis.Miktar)
        {
            ModelState.AddModelError("", "Yetersiz stok! Bu kadar ürün çıkışı yapılamaz.");
            return Page();
        }

        urun.MevcutStok -= StokCikis.Miktar;

        _context.StokCikis.Add(StokCikis);

        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}