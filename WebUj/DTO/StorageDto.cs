using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebUj.DTO
{
    // DTO (Data Transfer Object)
    // Adatok továbbítására használják az egyes rétegek között
    // Olyan objektumok, amelyek csak a szükséges adatokat tartalmazzák
    public class StorageDto
    {
        public int ID { get; set; }

        public int Row { get; set; }

        public int Column { get; set; }

        public int Shelf { get; set; }

        public int Cell { get; set; }

        public string? ProductName { get; set; }

        public Nullable<int> Price { get; set; }

        public Nullable<int> MaxQuantity { get; set; }

        public Nullable<int> Quantity { get; set; }

        public Nullable<int> Reserved { get; set; }

    }
}
