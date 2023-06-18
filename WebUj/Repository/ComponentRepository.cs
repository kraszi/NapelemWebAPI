using WebUj.Interfaces;
using WebUj.Models;

namespace WebUj.Repository
{

    

    public class ComponentRepository : ComponentInterface
    {

        private readonly APIDbContext _context;

        public ComponentRepository(APIDbContext context) 
        {
            _context = context;
        }

        // Entity Frameworkkel közvetlen adatbázis elérés
        // Függvények:

        public Component GetComponentById(int id)
        {
            return _context.Components.FirstOrDefault(c => c.ID == id);
        }

        public Component GetComponentByStorageId(int StorageId)
        {
            return _context.Components.FirstOrDefault(c => c.StorageID == StorageId);
        }

        public IEnumerable<Component> GetComponents()
        {
            return _context.Components.ToList();
        }

        public void CreateComponent(Component component)
        {
            _context.Components.Add(component);
            _context.SaveChanges();
        }


    }
}
