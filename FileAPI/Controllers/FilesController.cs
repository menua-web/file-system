using Application.IServices;
using DAL.Exceptions;
using DtoModels.EntityDtoModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileAPI.Controllers
{
    [Route("api/[controller]")]
    public class FilesController : Controller
    {

        private readonly IFileService _fileService;
        public FilesController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(200, Type = typeof(long))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateFile(FileDto file)
        {
            try
            {
                if (file?.File == null)
                {
                    return BadRequest("File not found.");
                }

                long newFileId = await _fileService.CreateAsync(file);
                return Ok(newFileId);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteFile(long id)
        {
            try
            {
                await _fileService.DeleteAsync(id);
                return Ok();
            }
            catch (EntityNotFoundException)
            {
                return NotFound("File not found to delete.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<FileDto>))]
        public async Task<IActionResult> Files()
        {
            var files = await _fileService.GetAsync();
            return Ok(files);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(FileDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetFile(int id)
        {
            var file = await _fileService.GetAsync(id);
            if (file == null) return NotFound();
            return Ok(file);
        }

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateFile(FileDto file)
        {
            try
            {
                await _fileService.UpdateAsync(file);
                return Ok();
            }
            catch (EntityNotFoundException)
            {
                return NotFound("File not found to delete.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
