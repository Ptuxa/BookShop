using BookShop.Api.Models.dto.request;
using BookShop.Api.Models.dto.response;
using BookShop.Api.Models.Entities;
using BookShop.Api.Repositories.Interfaces;
using BookShop.Api.Services.Interfaces;
using BookShop.Api.Services.Mappers;

namespace BookShop.Api.Services
{
    public class BooksService : IBooksService
    {
        private readonly IBooksRepository _booksRepository;

        public BooksService(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public async Task<List<BookResponse>> GetAllBooks()
        {
            return BookMapper.ToBookResponseList(await _booksRepository.GetAll());
        }

        public async Task<BookResponse> GetBook(Guid id)
        {
            return BookMapper.ToBookResponse(await _booksRepository.GetById(id));
        }

        public async Task<BookResponse> CreateBook(BookRequest bookRequest)
        {
            return BookMapper.ToBookResponse(await _booksRepository.Save(BookMapper.ToBookEntity(bookRequest)));
        }

        public async Task<BookResponse> UpdateBook(Guid id, BookRequest bookRequest)
        {
            return BookMapper.ToBookResponse(await _booksRepository.Save(BookMapper.ToBookEntityPartialUpdate(id, bookRequest)));
        }

        public async Task DeleteBook(Guid id)
        {
            await _booksRepository.DeleteById(id);
        }
    }
}
