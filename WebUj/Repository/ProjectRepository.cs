using Microsoft.Identity.Client.Extensions.Msal;
using WebUj.Interfaces;
using WebUj.Models;

namespace WebUj.Repository
{
    public class ProjectRepository : ProjectInterface
    {

        private readonly APIDbContext _context;

        public ProjectRepository(APIDbContext context)
        {
            _context = context;
        }

        public void ChangeProjectStatus(int progressId)
        {
            var project = _context.Projets.FirstOrDefault(p => p.ProgressID == progressId);

            if (project != null)
            {
                var progress = _context.Progresses.FirstOrDefault(p => p.ID == progressId);
                if (progress != null)
                {
                    progress.InProgress = DateTime.Now;
                    _context.SaveChanges();
                }
            }
        }

        public void ChangeProjectStatusCompleted(int progressId)
        {
            var project = _context.Projets.FirstOrDefault(p => p.ProgressID == progressId);

            if (project != null)
            {
                var progress = _context.Progresses.FirstOrDefault(p => p.ID == progressId);
                if (progress != null)
                {
                    progress.Completed = DateTime.Now;
                    _context.SaveChanges();
                }
            }
        }

        public void ChangeProjectStatusDraft(int progressId)
        {
            var project = _context.Projets.FirstOrDefault(p => p.ProgressID == progressId);

            if (project != null)
            {
                var progress = _context.Progresses.FirstOrDefault(p => p.ID == progressId);
                if (progress != null)
                {
                    progress.Draft = DateTime.Now;
                    _context.SaveChanges();
                }
            }
        }

        public void ChangeProjectStatusFailed(int progressId)
        {
            var project = _context.Projets.FirstOrDefault(p => p.ProgressID == progressId);

            if (project != null)
            {
                var progress = _context.Progresses.FirstOrDefault(p => p.ID == progressId);
                if (progress != null)
                {
                    progress.Failed = DateTime.Now;
                    _context.SaveChanges();
                }
            }
        }

        public void ChangeProjectStatusNew(int progressId)
        {
            var project = _context.Projets.FirstOrDefault(p => p.ProgressID == progressId);

            if (project != null)
            {
                var progress = _context.Progresses.FirstOrDefault(p => p.ID == progressId);
                if (progress != null)
                {
                    progress.New = DateTime.Now;
                    _context.SaveChanges();
                }
            }
        }

        public void CreateProject(Project project)
        {
            _context.Projets.Add(project);
            _context.SaveChanges();
        }

        // Entity Frameworkkel közvetlen adatbázis elérés
        // Függvények:

        public Project GetProjectByEmployeeId(int employeeId)
        {
            return _context.Projets.FirstOrDefault(p => p.EmployeeID == employeeId);
        }

        public Project GetProjectById(int id)
        {
            return _context.Projets.FirstOrDefault(p => p.ID == id);
        }

        public Project GetProjectByProgressId(int progressId)
        {
            return _context.Projets.FirstOrDefault(p => p.ProgressID == progressId);
        }

        public IEnumerable<Models.Storage> GetProjectComponents(int projectId)
        {
            var components = _context.Components.ToList();
            var projects = _context.Projets.ToList();
            var storages = _context.Storages.ToList();

            var projectComponents = new List<Models.Storage>();

            foreach( var project in projects) 
            {
                if (project.ID == projectId) 
                {
                    foreach (var component in components) 
                    {
                        foreach (var storage in storages) 
                        {
                            if (component.StorageID == storage.ID) 
                            {
                                projectComponents.Add(storage);
                            }
                        }
                    }
                }
            }

            return projectComponents;

        }

        public IEnumerable<Project> GetProjects()
        {
            return _context.Projets.ToList();
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
        public bool UpdateProject(Project project)
        {
            _context.Update(project);
            return Save();
        }
    }
}
