using WebUj.Models;

namespace WebUj.Interfaces
{
    // A StorageRepository implementálja az itt megírt függvény deklarációkat
    public interface StorageInterface
    {
        Storage GetStorageById(int id);
        IEnumerable<Storage> GetStorages();
        IEnumerable<Component> GetMissingComponents();
        void CreateStorage(Storage storage);
        bool StockExist(int id);
        bool UpdateStorage(Storage storage);
    }
}
