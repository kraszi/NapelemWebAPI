namespace WebUj.DTO
{
    // DTO (Data Transfer Object)
    // Adatok továbbítására használják az egyes rétegek között
    // Olyan objektumok, amelyek csak a szükséges adatokat tartalmazzák
    public class ProgressDto
    {

        public int ID { get; set; }

        public int ProjectID { get; set; }

        public System.DateTime New { get; set; }
        public Nullable<System.DateTime> Draft { get; set; }
        public Nullable<System.DateTime> Wait { get; set; }
        public Nullable<System.DateTime> Scheduled { get; set; }
        public Nullable<System.DateTime> InProgress { get; set; }
        public Nullable<System.DateTime> Completed { get; set; }
        public Nullable<System.DateTime> Failed { get; set; }

    }
}
