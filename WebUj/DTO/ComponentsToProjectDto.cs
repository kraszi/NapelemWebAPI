using System.ComponentModel.DataAnnotations.Schema;

namespace WebUj.DTO
{
    // DTO (Data Transfer Object)
    // Adatok továbbítására használják az egyes rétegek között
    // Olyan objektumok, amelyek csak a szükséges adatokat tartalmazzák
    public class ComponentsToProjectDto
    {
        public int ID { get; set; }

        public int ComponentID { get; set; }

        public int Quantity { get; set; }

        public int ProjectID { get; set; }
    }
}
