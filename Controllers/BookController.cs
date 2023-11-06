using BookManagementAPI.Implementation;
using BookManagementAPI.Models;
using BookManagementAPI.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManagementAPI.Controllers
{
    [Route("api/Book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private BookManager bookManager;

        public BookController(BookManager bookManager)
        {
            this.bookManager = bookManager;
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<BookDTO> GetBook(int id)
        {
            try
            {
                return Ok(bookManager.GetBook(id));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<BookDTO>> GetBooks()
        {
            try
            {
                return Ok(bookManager.GetBooks());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("search")]
        public ActionResult<IEnumerable<BookDTO>> SearchBooks(SearchBookDTO book)
        {
            try
            {
                return Ok(bookManager.SearchBooks(book));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult AddBook([FromForm]AddBookDTO book)
        {
            try
            {
                bookManager.AddBook(book);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateBook(BookDTO book)
        {
            try
            {
                bookManager.UpdateBook(book);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteBook(int id)
        {
            try
            {
                bookManager.DeleteBook(id);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
