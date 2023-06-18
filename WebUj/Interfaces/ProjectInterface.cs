using WebUj.Models;

namespace WebUj.Interfaces
{
    // A ProjectRepository implementálja az itt megírt függvény deklarációkat
    public interface ProjectInterface
    {
        IEnumerable<Project> GetProjects();
        Project GetProjectById(int id);
        Project GetProjectByEmployeeId(int employeeId);
        Project GetProjectByProgressId(int progressId);
        void ChangeProjectStatus(int progressId);
        void ChangeProjectStatusCompleted(int progressId);
        void ChangeProjectStatusFailed(int progressId);
        void ChangeProjectStatusDraft(int progressId);
        void ChangeProjectStatusNew(int progressId);
        void CreateProject(Project project);
        bool UpdateProject(Project project);
        bool StockExist(int id);
        IEnumerable<Storage> GetProjectComponents(int projectId);

    }
}
