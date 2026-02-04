using System.ComponentModel.DataAnnotations;

namespace CrudMySQL.Classic.Models
{
    public class Produit
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nom { get; set; } = string.Empty;

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Le prix doit être positif")]
        public double Prix { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [Required]
        public string Categorie { get; set; } = string.Empty;

        public DateTime DateCreation { get; set; } = DateTime.Now;
    }
}
