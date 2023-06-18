namespace WebUj.DTO
{
    // DTO (Data Transfer Object)
    // Adatok továbbítására használják az egyes rétegek között
    // Olyan objektumok, amelyek csak a szükséges adatokat tartalmazzák
    public class ComponentDto
    {
        public int ID { get; set; }
        public int StorageID { get; set; }

        public int RequiredQuantity { get; set; }

    }
}
