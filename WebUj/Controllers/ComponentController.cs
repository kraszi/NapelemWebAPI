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
    public class ComponentController : ControllerBase
    {
        private readonly ComponentInterface _componentInterface;
        private readonly IMapper _mapper;

        public ComponentController(ComponentInterface componentInterface, IMapper mapper)
        {
            _componentInterface = componentInterface;
            _mapper = mapper;
        }

        // WebAPI Endpoints:

        /// <summary>
        /// returns a component by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("id/{id}")]
        public IActionResult GetComponentById(int id) 
        {
            var component = _componentInterface.GetComponentById(id);

            if (component == null)
                return NotFound();

            var componentDto = _mapper.Map<Component, ComponentDto>(component);

            return Ok(componentDto);
        }

        /// <summary>
        /// returns a component by storageid
        /// </summary>
        /// <param name="storageid"></param>
        /// <returns></returns>
        [HttpGet("storageid/{storageid}")]
        public IActionResult GetComponentByStorageId(int storageid) 
        {
            var component = _componentInterface.GetComponentByStorageId(storageid);

            if (component == null)
                return NotFound();

            var componentDto = _mapper.Map<Component, ComponentDto>(component);

            return Ok(componentDto);
        }

        /// <summary>
        /// returns all components from the database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetComponents()
        {
            var components = _componentInterface.GetComponents();

            if (!components.Any())
                return NotFound();

            var componentDtos = _mapper.Map<IEnumerable<Component>, IEnumerable<ComponentDto>>(components);
            return Ok(componentDtos);
        }

        /// <summary>
        /// create a new employee
        /// </summary>
        /// <param name="componentDto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateComponent(ComponentDto componentDto)
        {
            var component = _mapper.Map<ComponentDto, Component>(componentDto);
            _componentInterface.CreateComponent(component);
            return Ok();
        }
    }
}
