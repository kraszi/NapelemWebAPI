using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebUj.DTO
{
    // DTO (Data Transfer Object)
    // Adatok továbbítására használják az egyes rétegek között
    // Olyan objektumok, amelyek csak a szükséges adatokat tartalmazzák
    public class EmployeeDto
    {
        public int ID { get; set; }

        public string? Name { get; set; }

        public string? Username { get; set; }

        public string? Password { get; set; }

        public string? UserType { get; set; }
    }
}
