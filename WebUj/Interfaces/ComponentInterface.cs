using WebUj.Models;

namespace WebUj.Interfaces
{
    // A ComponentRepository implementálja az itt megírt függvény deklarációkat
    public interface ComponentInterface
    {
        Component GetComponentById(int id);
        Component GetComponentByStorageId(int StorageId);
        IEnumerable<Component> GetComponents(); 
        void CreateComponent(Component component);
    }
}
