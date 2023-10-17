using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepoPattrenWithUnitOfWork.Core;
using RepoPattrenWithUnitOfWork.Core.CQRS.Commands.Author;
using RepoPattrenWithUnitOfWork.Core.CQRS.Querys.Author;
using RepoPattrenWithUnitOfWork.Core.Data;
using RepoPattrenWithUnitOfWork.Core.Interface;
using RepoPattrenWithUnitOfWork.Core.Interface.Service;
using RepoPattrenWithUnitOfWork.Core.Models;
using RepoPattrenWithUnitOfWork.Core.Service;
using RepoPattrenWithUnitOfWork.EF;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace RepositryPatternWithUnitOfWork.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        //private readonly IBaseRepository<Author> _authorsRepositry;
        //private readonly IUnitOfWork _unitOfWork;

        private readonly IAuthorService _AuthorService;
        private readonly IMediator _mediatR;
        private readonly ILogger<AuthorsController> _logger;

        public AuthorsController(IAuthorService authorService, IMediator mediatR, ILogger<AuthorsController> logger)
        {
            _AuthorService = authorService;
            _mediatR = mediatR;
            _logger = logger;
        }

        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] GetByIdAuthorQuery query)
        {
            var result = await _mediatR.Send(query);

            return result.Value != null ? (IActionResult)Ok(result.Value) : NotFound();
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllAuthorQuery query)
        {
        
            var result = await _mediatR.Send(query);

            return result != null ? (IActionResult)Ok(result) : NotFound();
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] AddAuthorCommand command)
        {

            var result = await _mediatR.Send(command);
            return result != null ? (IActionResult) Ok(result) : NotFound();

            //return Ok(_AuthorService.Add(entity));
        }   

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteAuthorCommand command)
        {
            var result = await _mediatR.Send(command);
            return result.Value != null ? (IActionResult)Ok(result.Value) : NotFound();

            //_AuthorService.Delete(entity);
            //return Ok();
        }
        
        [HttpGet("Find")]
        public async Task<IActionResult> Find([FromQuery] FindAuthorQuery query)
        {
            var result = await _mediatR.Send(query);

            return result.Value != null ? (IActionResult)Ok(result.Value) : NotFound();

            //return Ok(_AuthorService.Find(id));
        }
        [HttpGet("FindAll")]
        public async Task<IActionResult> FindAll([FromQuery] FindAllAuthorQuery query)
        {
            var result = await _mediatR.Send(query);

            return result.Value != null ? (IActionResult)Ok(result.Value) : NotFound();

           // return Ok(_AuthorService.FindAll(name));
        }        
    
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateAuthorCommand command)
        {
            var result = await _mediatR.Send(command);
            return result.Value != null ? (IActionResult)Ok(result.Value) : NotFound();

            //return Ok(_AuthorService.Update(entity));
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
