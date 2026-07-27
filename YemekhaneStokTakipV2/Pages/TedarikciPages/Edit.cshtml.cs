using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using YemekhaneStokTakipV2.Models;
using YemekhaneStokTakipV2.Data;

namespace YemekhaneStokTakipV2.Pages.TedarikciPages;

[Authorize(Roles = "Yonetici")]
public class EditModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public EditModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
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

        Tedarikci = tedarikci;

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(Tedarikci).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TedarikciExists(Tedarikci.TedarikciId))
            {
                return NotFound();
            }

            throw;
        }

        return RedirectToPage("./Index");
    }

    private bool TedarikciExists(int tedarikciid)
    {
        return _context.Tedarikciler.Any(e => e.TedarikciId == tedarikciid);
    }
}