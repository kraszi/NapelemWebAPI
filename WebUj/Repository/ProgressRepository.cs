using WebUj.Interfaces;
using WebUj.Models;

namespace WebUj.Repository
{
    public class ProgressRepository : ProgressInterface
    {

        private readonly APIDbContext _context;

        public ProgressRepository(APIDbContext context)
        {
            _context = context;
        }

        public void CreateProgress(Progress progress)
        {
            _context.Progresses.Add(progress);
            _context.SaveChanges();
        }

        // Entity Frameworkkel közvetlen adatbázis elérés
        // Függvények:

        public Progress GetProgressById(int id)
        {
            return _context.Progresses.FirstOrDefault(p => p.ID == id);
        }

        public Progress GetProgressByProjectId(int projectId)
        {
            return _context.Progresses.FirstOrDefault(p => p.ProjectID == projectId);
        }

        public IEnumerable<Progress> GetProgresses()
        {
            return _context.Progresses.ToList();
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
        public bool UpdateProgress(Progress progress)
        {
            _context.Update(progress);
            return Save();
        }



    }
}
