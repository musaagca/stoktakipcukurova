using Microsoft.AspNetCore.Mvc.RazorPages;
using YemekhaneStokTakipV2.Data;

namespace YemekhaneStokTakipV2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public int ToplamUrun { get; set; }
        public int ToplamKategori { get; set; }
        public int ToplamTedarikci { get; set; }
        public int ToplamStokGiris { get; set; }
        public int ToplamStokCikis { get; set; }

        public void OnGet()
        {
            ToplamUrun = _context.Urunler.Count();
            ToplamKategori = _context.Kategoriler.Count();
            ToplamTedarikci = _context.Tedarikciler.Count();
            ToplamStokGiris = _context.StokGiris.Count();
            ToplamStokCikis = _context.StokCikis.Count();
        }
    }
}