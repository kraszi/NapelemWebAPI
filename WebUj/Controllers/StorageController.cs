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
    public class StorageController : ControllerBase
    {
        private readonly StorageInterface _storageInterface;
        private readonly IMapper _mapper;

        public StorageController(StorageInterface storageInterface, IMapper mapper)
        {
            _storageInterface = storageInterface;
            _mapper = mapper;
        }

        // WebAPI Endpoints:

        /// <summary>
        /// returns all storages from the database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetStorages() 
        {
            var storages = _storageInterface.GetStorages();

            if (!storages.Any())
                return NotFound();

            var storageDtos = _mapper.Map<IEnumerable<Storage>, IEnumerable<StorageDto>>(storages);
            return Ok(storageDtos);
        }

        /// <summary>
        /// returns a storage by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("id/{id}")]
        public IActionResult GetStorageById(int id)
        {
            var storage = _storageInterface.GetStorageById(id);

            if (storage == null)
                return NotFound();

            var storageDto = _mapper.Map<Storage, StorageDto>(storage);

            return Ok(storageDto);
        }

        /// <summary>
        /// returns missing components (with reserved taking into)
        /// </summary>
        /// <returns></returns>
        [HttpGet("components")]
        public IActionResult GetMissingComponents() 
        {
            var missingComponents = _storageInterface.GetMissingComponents();

            if (missingComponents == null)
                return NotFound();

            return Ok(missingComponents);
        }

        /// <summary>
        /// create a new employee
        /// </summary>
        /// <param name="storageDto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateStorage(StorageDto storageDto)
        {
            var storage = _mapper.Map<StorageDto, Storage>(storageDto);
            _storageInterface.CreateStorage(storage);
            return Ok();
        }

        /// <summary>
        /// create a new employee
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storageDto"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult UpdateStorage(int id, [FromBody] StorageDto storageDto)
        {
            if (storageDto == null)
                return BadRequest(ModelState);

            if (!_storageInterface.StockExist(id))
                return NotFound();

            var stockMap = _mapper.Map<Storage>(storageDto);

            if (!_storageInterface.UpdateStorage(stockMap))
            {
                ModelState.AddModelError("", "Update Error");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

    }
}
