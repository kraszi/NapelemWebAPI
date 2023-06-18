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
    public class ComponentsToProjectController : Controller
    {
        private readonly ComponentsToProjectInterface _componentsToProjectInterface;
        private readonly IMapper _mapper;

        public ComponentsToProjectController(ComponentsToProjectInterface componentsToProjectInterface, IMapper mapper)
        {
            _componentsToProjectInterface = componentsToProjectInterface;
            _mapper = mapper;
        }

        /// <summary>
        /// assign one component to a project
        /// </summary>
        /// <param name="componentsToProjectDto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AssignComponentsToProject(ComponentsToProjectDto componentsToProjectDto)
        {
            _componentsToProjectInterface.AssignComponentsToProject(componentsToProjectDto.ComponentID, componentsToProjectDto.Quantity, componentsToProjectDto.ProjectID);
            return Ok();
        }



        /// <summary>
        /// return components by project id
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetComponentsByProjectId(int projectId)
        {
            var componentsById = _componentsToProjectInterface.GetComponentsByProjectId(projectId);

            if (componentsById == null)
                return NotFound();

            return Ok(componentsById);
        }
    }
}
