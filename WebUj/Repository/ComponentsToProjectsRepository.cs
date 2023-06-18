using WebUj.Interfaces;
using WebUj.Models;

namespace WebUj.Repository
{
    public class ComponentsToProjectsRepository : ComponentsToProjectInterface
    {
        private readonly APIDbContext _context;

        public ComponentsToProjectsRepository(APIDbContext context) 
        {
            _context = context;
        }


        // Entity Frameworkkel közvetlen adatbázis elérés
        // Függvények:

        public void AssignComponentsToProject(int componentId, int quantity, int projectId)
        {
            
            var newComponentToProject = new ComponentsToProject
            {
                ComponentID = componentId, 
                Quantity = quantity,
                ProjectID = projectId
            };

            _context.ComponentsToProjects.Add(newComponentToProject);
            _context.SaveChanges();
        }

        public IEnumerable<ComponentsToProject> GetComponentsByProjectId(int projectId)
        {
            return _context.ComponentsToProjects.Where(ctp => ctp.ProjectID == projectId).ToList();
        }
    }
}
