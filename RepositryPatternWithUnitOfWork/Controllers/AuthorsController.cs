using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepoPattrenWithUnitOfWork.Core;
using RepoPattrenWithUnitOfWork.Core.Data;
using RepoPattrenWithUnitOfWork.Core.Interface;
using RepoPattrenWithUnitOfWork.Core.Interface.Service;
using RepoPattrenWithUnitOfWork.Core.Models;
using RepoPattrenWithUnitOfWork.Core.Service;
using RepoPattrenWithUnitOfWork.EF;

namespace RepositryPatternWithUnitOfWork.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        //private readonly IBaseRepository<Author> _authorsRepositry;
        //private readonly IUnitOfWork _unitOfWork;
        private readonly AuthorService _AuthorService;

        public AuthorsController(AuthorService authorService)
        {
            _AuthorService = authorService;
        }

        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await _AuthorService.GetByIdAsync(id));
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll(string name)
        {
            return Ok(_AuthorService.FindAll(name));
        }
        [HttpPost("Add")]
        public IActionResult Add(DtoAuthor entity)
        {
            return Ok(_AuthorService.Add(entity));
        }   

        [HttpDelete("Delete")]
        public IActionResult Delete(DtoAuthor entity)
        {
            _AuthorService.Delete(entity);
            return Ok();
        }
        
        [HttpGet("Find")]
        public IActionResult Find(int id)
        {
            return Ok(_AuthorService.Find(id));
        }
        [HttpGet("FindAll")]
        public IActionResult FindAll(string name)
        {
            return Ok(_AuthorService.FindAll(name));
        }        
    
        [HttpPut("Update")]
        public IActionResult Update(DtoAuthor entity)
        {
            return Ok(_AuthorService.Update(entity));
        }

        //[HttpGet]
        //public IActionResult GetById(int id) {

        //  // return Ok(_unitOfWork.Authors.GetById(id));

        //}

        // this code was for RepositryPattern 

        //public AuthorsController(IBaseRepository<Author> authorsRepositry)
        //{
        //    _authorsRepositry = authorsRepositry;
        //} 
        //public AuthorsController(IUnitOfWork unitOfWork)
        //{
        //    _unitOfWork = unitOfWork;
        //}

        //[HttpGet]
        //public IActionResult GetById(int id) {

        //   return Ok(_authorsRepositry.GetById(id)); 

        //}

        //[HttpGet("GetByIdAsync")]
        //public async Task<IActionResult> GetByIdAsync(int id)
        //{
        //    return Ok(await _authorsRepositry.GetByIdAsync(id));
        //} 


    }
}
