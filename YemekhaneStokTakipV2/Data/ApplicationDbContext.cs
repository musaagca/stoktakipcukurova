using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YemekhaneStokTakipV2.Models;

namespace YemekhaneStokTakipV2.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Tedarikci> Tedarikciler { get; set; }
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<StokGiris> StokGiris { get; set; }
        public DbSet<StokCikis> StokCikis { get; set; }
    }
}