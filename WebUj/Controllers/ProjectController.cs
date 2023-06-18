using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebUj.DTO;
using WebUj.Interfaces;
using WebUj.Models;

namespace WebUj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ProjectInterface _projectInterface;
        private readonly IMapper _mapper;

        public ProjectController(ProjectInterface projectInterface, IMapper mapper)
        {
            _projectInterface = projectInterface;
            _mapper = mapper;
        }

        // WebAPI Endpoints:

        /// <summary>
        /// returns all projects from the database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetEmployees()
        {
            var projects = _projectInterface.GetProjects();

            if (!projects.Any())
                return NotFound();

            var projectsDtos = _mapper.Map<IEnumerable<Project>, IEnumerable<ProjectDto>>(projects);
            return Ok(projectsDtos);
        }

        /// <summary>
        /// returns a project by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("id/{id}")]
        public IActionResult GetProjectById(int id)
        {
            var project = _projectInterface.GetProjectById(id);

            if (project == null)
                return NotFound();

            var projectDto = _mapper.Map<Project, ProjectDto>(project);

            return Ok(projectDto);
        }

        /// <summary>
        /// returns a project by employeeid
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        [HttpGet("employeeid/{employeeid}")]
        public IActionResult GetProjectByEmployeeId(int employeeId)
        {
            var project = _projectInterface.GetProjectByEmployeeId(employeeId);

            if (project == null)
                return NotFound();

            var projectDto = _mapper.Map<Project, ProjectDto>(project);

            return Ok(projectDto);
        }

        /// <summary>
        /// returns a project by progressid
        /// </summary>
        /// <param name="progressId"></param>
        /// <returns></returns>
        [HttpGet("progressid/{progressid}")]
        public IActionResult GetProjectByProgressId(int progressId)
        {
            var project = _projectInterface.GetProjectByProgressId(progressId);

            if (project == null)
                return NotFound();

            var projectDto = _mapper.Map<Project, ProjectDto>(project);

            return Ok(projectDto);
        }

        /// <summary>
        /// change project status with progressid (inprogress)
        /// </summary>
        /// <param name="progressId"></param>
        /// <returns></returns>
        [HttpGet("projectstat/{progressid}")]
        public IActionResult ChangeProjectStatus(int progressId)
        {
            _projectInterface.ChangeProjectStatus(progressId);

            return Ok("Sikeres módosítás");

        }

        /// <summary>
        /// change project status completed
        /// </summary>
        /// <param name="progressId"></param>
        /// <returns></returns>
        [HttpGet("projectstatcompleted/{progressid}")]
        public IActionResult ChangeProjectStatusCompleted(int progressId)
        {
            _projectInterface.ChangeProjectStatusCompleted(progressId);

            return Ok("Sikeres módosítás");

        }

        /// <summary>
        /// change project status failed
        /// </summary>
        /// <param name="progressId"></param>
        /// <returns></returns>
        [HttpGet("projectstatfailed/{progressid}")]
        public IActionResult ChangeProjectStatusFailed(int progressId)
        {
            _projectInterface.ChangeProjectStatusFailed(progressId);

            return Ok("Sikeres módosítás");

        }

        /// <summary>
        /// change project status draft
        /// </summary>
        /// <param name="progressId"></param>
        /// <returns></returns>
        [HttpGet("projectstatdraft/{progressid}")]
        public IActionResult ChangeProjectStatusDraft(int progressId)
        {
            _projectInterface.ChangeProjectStatusDraft(progressId);

            return Ok("Sikeres módosítás");

        }

        // ChangeProjectStatusNew

        /// <summary>
        /// change project status new
        /// </summary>
        /// <param name="progressId"></param>
        /// <returns></returns>
        [HttpGet("projectstatnew/{progressid}")]
        public IActionResult ChangeProjectStatusNew(int progressId)
        {
            _projectInterface.ChangeProjectStatusNew(progressId);

            return Ok("Sikeres módosítás");

        }

        /// <summary>
        /// returns project components with row, column, shelf, cell
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        [HttpGet("projectcomponents/{projectid}")]
        public IActionResult getProjectComponents(int projectId) 
        {
            var projectComponents = _projectInterface.GetProjectComponents(projectId);

            if (!projectComponents.Any())
                return NotFound();

            return Ok(projectComponents);
        }

        /// <summary>
        /// create a new employee
        /// </summary>
        /// <param name="projectDto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateProject(ProjectDto projectDto)
        {
            var project = _mapper.Map<ProjectDto, Project>(projectDto);
            _projectInterface.CreateProject(project);
            return Ok();
        }

        /// <summary>
        /// create a new employee
        /// </summary>
        /// <param name="id"></param>
        /// <param name="projectDto"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult UpdateProject(int id, [FromBody] ProjectDto projectDto)
        {
            if (projectDto == null)
                return BadRequest(ModelState);

            if (!_projectInterface.StockExist(id))
                return NotFound();

            var stockMap = _mapper.Map<Project>(projectDto);

            if (!_projectInterface.UpdateProject(stockMap))
            {
                ModelState.AddModelError("", "Update Error");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
