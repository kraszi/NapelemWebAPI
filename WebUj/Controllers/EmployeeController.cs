using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebUj.DTO;
using WebUj.Helper;
using WebUj.Interfaces;
using WebUj.Models;

namespace WebUj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {

        private readonly EmployeeInterface _employeeInterface;
        private readonly IMapper _mapper;

        public EmployeeController(EmployeeInterface employeeInterface, IMapper mapper) 
        {
            _employeeInterface = employeeInterface;
            _mapper = mapper;
        }

        // WebAPI Endpoints:

        /// <summary>
        /// create a new employee
        /// </summary>
        /// <param name="employeeDto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateEmployee(EmployeeDto employeeDto)
        { 
            var employee = _mapper.Map<EmployeeDto, Employee>(employeeDto);
            _employeeInterface.CreateEmployee(employee);
            return Ok();
        }

        /// <summary>
        /// returns an employee by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("id/{id}")]
        public IActionResult GetEmployee(int id)
        {
            var employee = _employeeInterface.GetEmployeeById(id);

            if (employee == null)
                return NotFound();

            var employeeDto = _mapper.Map<Employee, EmployeeDto>(employee);

            return Ok(employeeDto);
        }

        /// <summary>
        /// returns an employee by username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        [HttpGet("username/{username}")]
        public IActionResult GetEmployee(string username) 
        {
            var employee = _employeeInterface.GetEmployeeByUsername(username);

            if (employee == null)
                return NotFound();

            var employeeDto = _mapper.Map<Employee, EmployeeDto>(employee);

            return Ok(employeeDto);
        }

        /// <summary>
        /// returns all employees from the database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetEmployees() 
        {
            var employees = _employeeInterface.GetEmployees();

            if (!employees.Any())
                return NotFound();

            var employeeDtos = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(employees);
            return Ok(employeeDtos);
        }

        /// <summary>
        /// return employee object if authenticated is succesful, else return a string with error msg
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public IActionResult Login([FromBody] HelperUser helperUser)
        {
            bool isAuthenticated = false;

            Employee employee = _employeeInterface.GetEmployeeByUsernameAndPassword(helperUser.Username, helperUser.Password);
            if (employee != null) 
            {
                isAuthenticated = true;
            }

            if (isAuthenticated)
            {
                //return Ok(employee.UserType.ToString());
                return Ok(employee);
            }

            return Unauthorized("Hibás felhasználónév vagy jelszó");
        }

    }
}
