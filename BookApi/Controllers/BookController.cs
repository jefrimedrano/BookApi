using BookApi.Entity;
using BookApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class BookController : ControllerBase
    {
        BookServices bookServices;
        public BookController()
        {
            bookServices = new BookServices();
        }

        [Route("V1/Books")]
        [HttpGet]
        public async Task<ActionResult> Books()
        {
            ResultModel result = new ResultModel();
            List<Book> books = new List<Book>();
            result = await bookServices.GetAll();

            if (result.Success)
            {
                books = (List<Book>)result.Data;
                return Ok(books);
            }

            if (result.Messages == "NotFound")
            {
                return NotFound();
            }

            return BadRequest();
        }


        [Route("V1/Books/{id}")]
        [HttpGet]
        public async Task<ActionResult> Books(int id)
        {
            ResultModel result = new ResultModel();
            Book book = new Book();
            result = await bookServices.GetById(id);

            if (result.Success)
            {
                book = (Book)result.Data;
                return Ok(book);
            }

            if (result.Messages == "NotFound")
            {
                return NotFound();
            }

            return BadRequest();
        }

        [Route("V1/Books")]
        [HttpPost]
        public async Task<ActionResult> Books(Book book)
        {
             
            ResultModel result = new ResultModel();
            Book books = new Book();
            result = await bookServices.Create(book);

            if (result.Success)
            {
                books = (Book)result.Data;
                return Ok(books);
            }

            if (result.Messages == "NotFound")
            {
                return NotFound();
            }

            return BadRequest();
        }

        [Route("V1/Books/{id}")]
        [HttpPut]
        public async Task<ActionResult> UpDate(Book book)
        {
            ResultModel result = new ResultModel();
            Book books = new Book();
            result = await bookServices.UpDate(book);

            if (result.Success)
            {
                books = (Book)result.Data;
                return Ok(books);
            }

            if (result.Messages == "NotFound")
            {
                return NotFound();
            }

            return BadRequest();
        }

        [Route("V1/Books/{id}")]
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            ResultModel result = new ResultModel();
            Book books = new Book();
            result = await bookServices.Delete(id);

            if (result.Success)
            {
                return Ok();
            }

            if (result.Messages == "NotFound")
            {
                return NotFound();
            }

            return BadRequest();
        }

    }
}
