using System.ComponentModel.DataAnnotations;

namespace YemekhaneStokTakipV2.Models
{
    public class Kategori
    {
        [Key]
        public int KategoriId { get; set; }

        [Required]
        public string KategoriAdi { get; set; } = string.Empty;
    }
}