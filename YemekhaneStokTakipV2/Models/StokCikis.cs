using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YemekhaneStokTakipV2.Models
{
    public class StokCikis
    {
        [Key]
        public int StokCikisId { get; set; }

        [ForeignKey("Urun")]
        public int UrunId { get; set; }

        public decimal Miktar { get; set; }

        public DateTime Tarih { get; set; }

        public string? Aciklama { get; set; }

        public Urun? Urun { get; set; }
    }
}