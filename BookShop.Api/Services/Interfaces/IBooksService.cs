using BookShop.Api.Models.dto.request;
using BookShop.Api.Models.dto.response;
using BookShop.Api.Models.Entities;

namespace BookShop.Api.Services.Interfaces
{
    public interface IBooksService
    {
        Task<BookResponse> CreateBook(BookRequest bookRequest);
        Task DeleteBook(Guid id);
        Task<List<BookResponse>> GetAllBooks();
        Task<BookResponse> GetBook(Guid id);
        Task<BookResponse> UpdateBook(Guid id, BookRequest bookRequest);
    }
}