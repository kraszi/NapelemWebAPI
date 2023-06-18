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
    public class ProgressController : ControllerBase
    {
        private readonly ProgressInterface _progressInterface;
        private readonly IMapper _mapper;

        public ProgressController(ProgressInterface progressInterface, IMapper mapper)
        {
            _progressInterface = progressInterface;
            _mapper = mapper;
        }

        // WebAPI Endpoints:

        /// <summary>
        /// returns a progress by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("id/{id}")]
        public IActionResult GetProgressById(int id) 
        {
            var progress = _progressInterface.GetProgressById(id);

            if (progress == null)
                return NotFound();

            var progressDto = _mapper.Map<Progress, ProgressDto>(progress);

            return Ok(progressDto);
        }

        /// <summary>
        /// returns a progress by projectid
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        [HttpGet("projectid/{projectid}")]
        public IActionResult GetProgressByProjectId(int projectId) 
        {
            var progress = _progressInterface.GetProgressByProjectId(projectId);

            if (progress == null)
                return NotFound();

            var progressDto = _mapper.Map<Progress, ProgressDto>(progress);

            return Ok(progressDto);
        }

        /// <summary>
        /// returns all progresses from the database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetProgresses() 
        {
            var progresses = _progressInterface.GetProgresses();

            if (!progresses.Any())
                return NotFound();

            var progressDtos = _mapper.Map<IEnumerable<Progress>, IEnumerable<ProgressDto>>(progresses);
            return Ok(progressDtos);
        }

        /// <summary>
        /// create a new employee
        /// </summary>
        /// <param name="progressDto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateProgress(ProgressDto progressDto)
        {
            var project = _mapper.Map<ProgressDto, Progress>(progressDto);
            _progressInterface.CreateProgress(project);
            return Ok();
        }

        /// <summary>
        /// create a new employee
        /// </summary>
        /// <param name="id"></param>
        /// <param name="progressDto"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult UpdateProgress(int id, [FromBody] ProgressDto progressDto)
        {
            if (progressDto == null)
                return BadRequest(ModelState);

            if (!_progressInterface.StockExist(id))
                return NotFound();

            var stockMap = _mapper.Map<Progress>(progressDto);

            if (!_progressInterface.UpdateProgress(stockMap))
            {
                ModelState.AddModelError("", "Update Error");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
