using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebUj.Models
{
    // Adatbázis tábla modellezése
    public class Storage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public int Row { get; set; }

        [Required]
        public int Column { get; set; }

        [Required]
        public int Shelf { get; set; }

        [Required]
        public int Cell { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public string? ProductName { get; set; }

        public Nullable<int> Price { get; set; }

        public Nullable<int> MaxQuantity { get; set; }

        public Nullable<int> Quantity { get; set; }

        public Nullable<int> Reserved { get; set; }

    }
}
