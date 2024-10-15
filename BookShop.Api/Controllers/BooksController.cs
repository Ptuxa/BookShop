using BookShop.Api.Models.dto.request;
using BookShop.Api.Models.dto.response;
using BookShop.Api.Models.Entities;
using BookShop.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;

        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpGet]
        public async Task<ActionResult<List<BookResponse>>> GetAllBooks()
        {
            return Ok(await _booksService.GetAllBooks());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<BookResponse>> GetBook(Guid id)
        {
            return Ok(await _booksService.GetBook(id));
        }

        [HttpPost]
        public async Task<ActionResult<BookResponse>> CreateBook([FromBody] BookRequest bookRequest)
        {
            return Ok(await _booksService.CreateBook(bookRequest));
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<BookResponse>> UpdateBook(Guid id, [FromBody] BookRequest bookRequest)
        {
            return Ok(await _booksService.UpdateBook(id, bookRequest));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<BookResponse>> DeleteBook(Guid id)
        {
            await _booksService.DeleteBook(id);

            return NoContent();
        }
    }
}
