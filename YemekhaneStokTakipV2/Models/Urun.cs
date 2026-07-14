using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YemekhaneStokTakipV2.Models
{
    public class Urun
    {
        [Key]
        public int UrunId { get; set; }

        [Required]
        public string UrunAdi { get; set; }

        [ForeignKey("Kategori")]
        public int KategoriId { get; set; }

        public string Birim { get; set; }

        public decimal MevcutStok { get; set; }

        public decimal KritikStok { get; set; }

        public Kategori? Kategori { get; set; }
    }
}