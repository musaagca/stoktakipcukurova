using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using YemekhaneStokTakipV2.Data;
using YemekhaneStokTakipV2.Models;

namespace YemekhaneStokTakipV2.Pages.KategoriPages;

[Authorize]
public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty(SupportsGet = true)]
    public string? Ara { get; set; }

    public IList<Kategori> Kategori { get; set; } = new List<Kategori>();

    public async Task OnGetAsync()
    {
        var q = _context.Kategoriler.AsQueryable();

        if (!string.IsNullOrWhiteSpace(Ara))
            q = q.Where(x => x.KategoriAdi.Contains(Ara));

        Kategori = await q.OrderBy(x => x.KategoriAdi).ToListAsync();
    }
}