using WebUj.Models;

namespace WebUj.Interfaces
{
    public interface ComponentsToProjectInterface
    {
        IEnumerable<ComponentsToProject> GetComponentsByProjectId(int projectId);

        void AssignComponentsToProject(int componentId, int Quantity, int projectId);
    }
}
