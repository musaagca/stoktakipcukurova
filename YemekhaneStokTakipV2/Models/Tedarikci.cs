using System.ComponentModel.DataAnnotations;

namespace YemekhaneStokTakipV2.Models
{
    public class Tedarikci
    {
        [Key]
        public int TedarikciId { get; set; }

        [Required]
        public string FirmaAdi { get; set; }

        public string? Telefon { get; set; }

        public string? Adres { get; set; }
    }
}