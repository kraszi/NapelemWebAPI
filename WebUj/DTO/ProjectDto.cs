using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebUj.DTO
{
    // DTO (Data Transfer Object)
    // Adatok továbbítására használják az egyes rétegek között
    // Olyan objektumok, amelyek csak a szükséges adatokat tartalmazzák
    public class ProjectDto
    {
        public int ID { get; set; }

        public int EmployeeID { get; set; }

        public int ProgressID { get; set; }

        public string Title { get; set; }

        public string Address { get; set; }

        public Nullable<int> ComponentsID { get; set; }

        public Nullable<int> WorkPrice { get; set; }

        public Nullable<int> FullPrice { get; set; }

        public Nullable<int> RequiredTime { get; set; }


    }
}
