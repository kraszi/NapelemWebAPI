using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebUj.Models
{
    // Adatbázis tábla modellezése
    public class Progress
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public int ProjectID { get; set; }

        [Required]
        public System.DateTime New { get; set; }
        public Nullable<System.DateTime> Draft { get; set; }
        public Nullable<System.DateTime> Wait { get; set; }
        public Nullable<System.DateTime> Scheduled { get; set; }
        public Nullable<System.DateTime> InProgress { get; set; }
        public Nullable<System.DateTime> Completed { get; set; }
        public Nullable<System.DateTime> Failed { get; set; }
    }
}
