using WebUj.Models;

namespace WebUj.Interfaces
{
    // Az EmployeeRepository implementálja az itt megírt függvény deklarációkat
    public interface EmployeeInterface
    {
        void CreateEmployee(Employee employee);
        Employee GetEmployeeById(int id);
        Employee GetEmployeeByUsername(string username);
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployeeByUsernameAndPassword(string username, string password);

    }
}
