using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using YemekhaneStokTakipV2.Data;
using YemekhaneStokTakipV2.Models;
namespace YemekhaneStokTakipV2.Pages.UrunPages;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;
    public IndexModel(ApplicationDbContext context) { _context = context; }
    [BindProperty(SupportsGet = true)] public string? Ara { get; set; }
    public IList<Urun> Urun { get; set; } = new List<Urun>();
    public async Task OnGetAsync()
    {
        var q = _context.Urunler.Include(x => x.Kategori).AsQueryable();
        if (!string.IsNullOrWhiteSpace(Ara)) q = q.Where(x => x.UrunAdi.Contains(Ara));
        Urun = await q.OrderBy(x => x.UrunAdi).ToListAsync();
    }
}