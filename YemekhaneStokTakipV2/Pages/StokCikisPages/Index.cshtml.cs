using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using YemekhaneStokTakipV2.Data;
using YemekhaneStokTakipV2.Models;

namespace YemekhaneStokTakipV2.Pages.StokCikisPages;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<StokCikis> StokCikis { get; set; } = default!;

    public async Task OnGetAsync()
    {
        StokCikis = await _context.StokCikis
            .Include(s => s.Urun)
            .ToListAsync();
    }
}