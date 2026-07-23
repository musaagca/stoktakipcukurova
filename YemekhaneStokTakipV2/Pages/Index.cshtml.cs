using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using YemekhaneStokTakipV2.Data;
using YemekhaneStokTakipV2.Models;

namespace YemekhaneStokTakipV2.Pages
{
    [Authorize]
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

        public IList<Urun> KritikUrunler { get; set; } = new List<Urun>();
        public IList<StokGiris> SonStokGirisleri { get; set; } = new List<StokGiris>();
        public IList<StokCikis> SonStokCikislari { get; set; } = new List<StokCikis>();

        public void OnGet()
        {
            ToplamUrun = _context.Urunler.Count();
            ToplamKategori = _context.Kategoriler.Count();
            ToplamTedarikci = _context.Tedarikciler.Count();
            ToplamStokGiris = _context.StokGiris.Count();
            ToplamStokCikis = _context.StokCikis.Count();

            KritikUrunler = _context.Urunler
                .Include(x => x.Kategori)
                .Where(x => x.MevcutStok <= x.KritikStok)
                .ToList();

            SonStokGirisleri = _context.StokGiris
                .Include(x => x.Urun)
                .Include(x => x.Tedarikci)
                .OrderByDescending(x => x.Tarih)
                .Take(5)
                .ToList();

            SonStokCikislari = _context.StokCikis
                .Include(x => x.Urun)
                .OrderByDescending(x => x.Tarih)
                .Take(5)
                .ToList();
        }
    }
}