using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using YemekhaneStokTakipV2.Models;
using YemekhaneStokTakipV2.Data;

namespace YemekhaneStokTakipV2.Pages.StokGirisPages;

public class DetailsModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DetailsModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public StokGiris StokGiris { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var stokgiris = await _context.StokGiris
            .FirstOrDefaultAsync(m => m.StokGirisId == id);

        if (stokgiris == null)
        {
            return NotFound();
        }

        StokGiris = stokgiris;

        return Page();
    }
}