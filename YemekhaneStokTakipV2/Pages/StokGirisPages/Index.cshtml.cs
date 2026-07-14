using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using YemekhaneStokTakipV2.Data;
using YemekhaneStokTakipV2.Models;

namespace YemekhaneStokTakipV2.Pages.StokGirisPages;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<StokGiris> StokGiris { get; set; } = default!;

    public async Task OnGetAsync()
    {
        StokGiris = await _context.StokGiris
            .Include(s => s.Urun)
            .Include(s => s.Tedarikci)
            .ToListAsync();
    }
}