using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepoPattrenWithUnitOfWork.Core;
using RepoPattrenWithUnitOfWork.Core.Const;
using RepoPattrenWithUnitOfWork.Core.CQRS.Commands.Book;
using RepoPattrenWithUnitOfWork.Core.CQRS.Querys.Book;
using RepoPattrenWithUnitOfWork.Core.Data;
using RepoPattrenWithUnitOfWork.Core.Interface;
using RepoPattrenWithUnitOfWork.Core.Interface.Service;
using RepoPattrenWithUnitOfWork.Core.Models;
using RepoPattrenWithUnitOfWork.Core.Service;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Reflection.Metadata.BlobBuilder;

namespace RepositryPatternWithUnitOfWork.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        //private readonly IBaseRepository<book> _booksRepositry;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBookService _BookService;
        private readonly IMediator _mediatR;
        private readonly ILogger<BooksController> _logger;

        //public BooksController(IUnitOfWork unitOfWork)
        //{
        //    _unitOfWork = unitOfWork;
        //}
        public BooksController(IBookService BookService, IMediator mediatR, ILogger<BooksController> logger)
        {
            _BookService = BookService;
            _mediatR = mediatR;
            _logger = logger;
        }

        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] GetByIdBookQuery query)
        {

            var result = await _mediatR.Send(query);

            return result.Value != null ? (IActionResult)Ok(result.Value) : NotFound();

            //return Ok(await _BookService.GetByIdAsync(id));
        }

        [HttpGet("GetAll")]
        public async Task <IActionResult> GetAll([FromQuery] GetAllBookQuery query)
        {
            var result = await _mediatR.Send(query);

            return result != null ? (IActionResult)Ok(result) : NotFound();
            // return Ok(await _BookService.GetAll());
        }
        [HttpGet("GetByName")]
        public async Task<IActionResult> GetByName([FromQuery] GetByNameQuery query)
        {
            var result = await _mediatR.Send(query);

            return result != null ? (IActionResult)Ok(result) : NotFound();

          //  return Ok(_BookService.FindAll(BookName));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateBookCommand command)
        {
            var result = await _mediatR.Send(command);

            return result.Value != null ? (IActionResult)Ok(result.Value) : NotFound();

            //return Ok(_BookService.update(entity));
        }

        //[HttpGet("GetAllWithAuthors")]
        //public IActionResult GetAllWithAuthors()
        //{
        //    return Ok(BookService.FindAll(e => e.Title.Contains("New Book"), new[] { "Author" }));// send name of table that we want include
        //}
        //[HttpGet("GetOrderd")]
        //public IActionResult GetOrderd()
        //{
        //    //return Ok(BookService.FindAll(e => e.Title.Contains("New Book"), null,null,b=>b.Id));//it will take orderbyAssending by default 
        //    return Ok(BookService.FindAll(e => e.Title.Contains("New Book"), null,null,b=>b.Id,OrderBy.Dssending));
        //}

        // have issue
        //[HttpPost("AddOne")]
        //public IActionResult AddOne()
        //{
        //    var book = _unitOfWork.Books.Add(new book { Title = "Test 4", AuthorId = 1 });
        //    _unitOfWork.Complete(); // to save book using unit of work
        //    return Ok(book);
        //}

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
