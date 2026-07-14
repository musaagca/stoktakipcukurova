using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using YemekhaneStokTakipV2.Models;
using YemekhaneStokTakipV2.Data;

namespace YemekhaneStokTakipV2.Pages.UrunPages;

public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public CreateModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Urun Urun { get; set; } = default!;

    public IActionResult OnGet()
    {
        ViewData["KategoriId"] = new SelectList(_context.Kategoriler, "KategoriId", "KategoriAdi");
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            ViewData["KategoriId"] = new SelectList(_context.Kategoriler, "KategoriId", "KategoriAdi");
            return Page();
        }

        _context.Urunler.Add(Urun);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}