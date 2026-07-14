using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using YemekhaneStokTakipV2.Models;
using YemekhaneStokTakipV2.Data;

namespace YemekhaneStokTakipV2.Pages.TedarikciPages;

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

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
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
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool TedarikciExists(int tedarikciid)
    {
        return _context.Tedarikciler.Any(e => e.TedarikciId == tedarikciid);
    }
}
