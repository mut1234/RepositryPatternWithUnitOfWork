using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepoPattrenWithUnitOfWork.Core;
using RepoPattrenWithUnitOfWork.Core.Interface;
using RepoPattrenWithUnitOfWork.Core.Models;
using RepoPattrenWithUnitOfWork.EF;

namespace RepositryPatternWithUnitOfWork.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        //private readonly IBaseRepository<Author> _authorsRepositry;
        private readonly IUnitOfWork _unitOfWork;


        [HttpGet]
        public IActionResult GetById(int id) {
        
           return Ok(_unitOfWork.Authors.GetById(id)); 

        }

        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await _unitOfWork.Authors.GetByIdAsync(id));
        }

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
