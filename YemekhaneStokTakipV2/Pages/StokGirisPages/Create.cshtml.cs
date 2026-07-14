using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YemekhaneStokTakipV2.Models;
using YemekhaneStokTakipV2.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace YemekhaneStokTakipV2.Pages.StokGirisPages;

public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public CreateModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        UrunListesi = new SelectList(_context.Urunler, "UrunId", "UrunAdi");
        TedarikciListesi = new SelectList(_context.Tedarikciler, "TedarikciId", "FirmaAdi");

        return Page();
    }
    public SelectList UrunListesi { get; set; } = default!;
    public SelectList TedarikciListesi { get; set; } = default!;
    [BindProperty]
    public StokGiris StokGiris { get; set; } = default!;

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var urun = await _context.Urunler.FindAsync(StokGiris.UrunId);

        if (urun == null)
        {
            return NotFound();
        }

        // Ürünün mevcut stokunu artır
        urun.MevcutStok += StokGiris.Miktar;

        // Stok girişini kaydet
        _context.StokGiris.Add(StokGiris);

        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}