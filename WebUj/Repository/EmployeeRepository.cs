using System.Text;
using WebUj.DTO;
using WebUj.Interfaces;
using WebUj.Models;
using System.Security.Cryptography;

namespace WebUj.Repository
{
    public class EmployeeRepository : EmployeeInterface
    {

        private readonly APIDbContext _context;

        public EmployeeRepository(APIDbContext context) 
        { 
            _context = context;
        }

        // Entity Frameworkkel közvetlen adatbázis elérés
        // Függvények:

        public void CreateEmployee(Employee employee)
        {
            SHA256 sha256 = SHA256.Create();
            byte[] passwordBytes = Encoding.UTF8.GetBytes(employee.Password);
            byte[] hashBytes = sha256.ComputeHash(passwordBytes);
            string passwordHash = Convert.ToBase64String(hashBytes);
            employee.Password = passwordHash;
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public Employee GetEmployeeById(int id)
        {
            return _context.Employees.FirstOrDefault(e => e.ID == id);
        }

        public Employee GetEmployeeByUsername(string username)
        {
            return _context.Employees.FirstOrDefault(e => e.Username == username);
        }

        public Employee GetEmployeeByUsernameAndPassword(string username, string password)
        {
            return _context.Employees.FirstOrDefault(e => e.Username == username && e.Password == password);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _context.Employees.ToList();
        }



    }
}
