using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using YemekhaneStokTakipV2.Models;
using YemekhaneStokTakipV2.Data;

namespace YemekhaneStokTakipV2.Pages.TedarikciPages;

public class DetailsModel : PageModel
{
    private readonly ApplicationDbContext _context;
    public DetailsModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public Tedarikci Tedarikci { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? tedarikciid)
    {
        if (tedarikciid is null)
        {
            return NotFound();
        }

        var tedarikci = await _context.Tedarikciler.FirstOrDefaultAsync(m => m.TedarikciId == tedarikciid);
        if (tedarikci is null)
        {
            return NotFound();
        }
        else
        {
            Tedarikci = tedarikci;
        }

        return Page();
    }
}
