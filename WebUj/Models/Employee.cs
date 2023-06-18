using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebUj.Models
{
    // Adatbázis tábla modellezése
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(40)")]
        public string? Name { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public string? Username { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(60)")]
        public string? Password { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string? UserType { get; set; }
    }
}
