using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebUj.Models
{
    // Adatbázis tábla modellezése
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public int EmployeeID { get; set; }

        [Required]
        public int ProgressID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(60)")]
        public string Address { get; set; }

        public Nullable<int> ComponentsID { get; set; }

        public Nullable<int> WorkPrice { get; set; }

        public Nullable<int> FullPrice { get; set; }

        public Nullable<int> RequiredTime { get; set; }
    }
}
