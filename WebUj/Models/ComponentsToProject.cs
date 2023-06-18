using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebUj.Models
{
    // Adatbázis tábla modellezése
    public class ComponentsToProject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public int ComponentID { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int ProjectID { get; set; }
    }
}
