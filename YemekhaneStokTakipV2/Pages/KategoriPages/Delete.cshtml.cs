using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using YemekhaneStokTakipV2.Data;
using YemekhaneStokTakipV2.Models;

namespace YemekhaneStokTakipV2.Pages.KategoriPages;

public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DeleteModel(ApplicationDbContext context)
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

        Kategori = await _context.Kategoriler
            .FirstOrDefaultAsync(m => m.KategoriId == id);

        if (Kategori == null)
        {
            return NotFound();
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var kategori = await _context.Kategoriler.FindAsync(id);

        if (kategori == null)
        {
            return NotFound();
        }

        try
        {
            _context.Kategoriler.Remove(kategori);
            await _context.SaveChangesAsync();

            TempData["Basari"] = "Kategori başarıyla silindi.";
        }
        catch (DbUpdateException)
        {
            TempData["Hata"] = "❌ Bu kategoriye bağlı ürünler bulunduğu için silinemez.";
        }

        return RedirectToPage("./Index");
    }
}