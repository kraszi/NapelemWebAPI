using WebUj.Models;

namespace WebUj.Interfaces
{
    // A ProgressRepository implementálja az itt megírt függvény deklarációkat
    public interface ProgressInterface
    {
        IEnumerable<Progress> GetProgresses();
        Progress GetProgressById(int id);
        Progress GetProgressByProjectId(int projectId);
        void CreateProgress (Progress progress);
        bool UpdateProgress(Progress progress);
        bool StockExist(int id);
    }
}
