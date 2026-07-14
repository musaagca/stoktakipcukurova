using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using YemekhaneStokTakipV2.Models;
using YemekhaneStokTakipV2.Data;

namespace YemekhaneStokTakipV2.Pages.StokCikisPages;

public class DetailsModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DetailsModel(ApplicationDbContext context)
    {
        _context = context;
    }

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

        return Page();
    }
}