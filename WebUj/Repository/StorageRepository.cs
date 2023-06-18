using Microsoft.AspNetCore.Mvc.TagHelpers;
using WebUj.Interfaces;
using WebUj.Models;

namespace WebUj.Repository
{
    public class StorageRepository : StorageInterface
    {

        private readonly APIDbContext _context;

        public StorageRepository(APIDbContext context)
        {
            _context = context;
        }
        public void CreateStorage(Storage storage)
        {
            _context.Storages.Add(storage);
            _context.SaveChanges();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
        public bool StockExist(int id)
        {
            return _context.Storages.Any(s => s.ID == id);
        }
        public bool UpdateStorage(Storage storage)
        {
            _context.Update(storage);
            return Save();
        }

        // Entity Frameworkkel közvetlen adatbázis elérés
        // Függvények:

        public IEnumerable<Component> GetMissingComponents()
        {
            var components = _context.Components.ToList();
            var storages = _context.Storages.ToList();

            var missingComponents = new List<Component>();

            foreach (var component in components)
            {
                foreach (var storage in storages) 
                {
                    // reserved == 1 -> lefoglalva
                    // reserved == 0 -> nincs lefoglalva
                    if (component.StorageID == storage.ID && storage.Reserved >= 1) 
                    {
                        missingComponents.Add(component);
                    } 
                }
            }
            return missingComponents;

        }

        public Storage GetStorageById(int id)
        {
            return _context.Storages.FirstOrDefault(s => s.ID == id);
        }

        public IEnumerable<Storage> GetStorages()
        {
            return _context.Storages.ToList();
        }

    }
}
