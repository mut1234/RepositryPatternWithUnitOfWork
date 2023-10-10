using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepoPattrenWithUnitOfWork.Core;
using RepoPattrenWithUnitOfWork.Core.Const;
using RepoPattrenWithUnitOfWork.Core.Interface;
using RepoPattrenWithUnitOfWork.Core.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace RepositryPatternWithUnitOfWork.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        //private readonly IBaseRepository<book> _booksRepositry;
        private readonly IUnitOfWork _unitOfWork;

        public BooksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {

            return Ok(_unitOfWork.Books.GetById(id));

        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_unitOfWork.Books.GetAll());
        }
        [HttpGet("GetByName")]
        public IActionResult GetByName()
        {
            return Ok(_unitOfWork.Books.Find(e=>e.Title== "New Book", new[] { "Author" }));// send name of table that we want include
        }
        [HttpGet("GetAllWithAuthors")]
        public IActionResult GetAllWithAuthors()
        {
            return Ok(_unitOfWork.Books.FindAll(e => e.Title.Contains("New Book"), new[] { "Author" }));// send name of table that we want include
        }
        [HttpGet("GetOrderd")]
        public IActionResult GetOrderd()
        {
            //return Ok(_unitOfWork.Books.FindAll(e => e.Title.Contains("New Book"), null,null,b=>b.Id));//it will take orderbyAssending by default 
            return Ok(_unitOfWork.Books.FindAll(e => e.Title.Contains("New Book"), null,null,b=>b.Id,OrderBy.Dssending));
        }

        [HttpPost("AddOne")]
        public IActionResult AddOne()
        {
            var book = _unitOfWork.Books.Add(new book { Title = "Test 4", AuthorId = 1 });
            _unitOfWork.Complete(); // to save book using unit of work
            return Ok(book);
        }

        // this code was for RepositryPattern 

        //public BooksController(IBaseRepository<book> booksRepositry)
        //{
        //    _booksRepositry = booksRepositry;
        //}

        //[HttpGet]
        //public IActionResult GetById(int id)
        //{

        //    return Ok(_booksRepositry.GetById(id));

        //}

        //[HttpGet("GetAll")]
        //public IActionResult GetAll()
        //{
        //    return Ok(_booksRepositry.GetAll());
        //}
        //[HttpGet("GetByName")]
        //public IActionResult GetByName()
        //{
        //    return Ok(_booksRepositry.Find(e=>e.Title== "New Book", new[] { "Author" }));// send name of table that we want include
        //}
        //[HttpGet("GetAllWithAuthors")]
        //public IActionResult GetAllWithAuthors()
        //{
        //    return Ok(_booksRepositry.FindAll(e => e.Title.Contains("New Book"), new[] { "Author" }));// send name of table that we want include
        //}
        //[HttpGet("GetOrderd")]
        //public IActionResult GetOrderd()
        //{
        //    //return Ok(_booksRepositry.FindAll(e => e.Title.Contains("New Book"), null,null,b=>b.Id));//it will take orderbyAssending by default 
        //    return Ok(_booksRepositry.FindAll(e => e.Title.Contains("New Book"), null,null,b=>b.Id,OrderBy.Dssending));
        //}

        //[HttpPost("AddOne")]
        //public IActionResult AddOne()
        //{
        //    return Ok(_booksRepositry.Add(new book { Title="Test 3",AuthorId=1}));
        //}
    }
}
