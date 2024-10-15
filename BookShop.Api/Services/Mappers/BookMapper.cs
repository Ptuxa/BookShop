using BookShop.Api.Models.dto.request;
using BookShop.Api.Models.dto.response;
using BookShop.Api.Models.Entities;

namespace BookShop.Api.Services.Mappers
{
    public class BookMapper
    {
        public static BookResponse ToBookResponse(BookEntity bookEntity)
        {
            return new BookResponse(bookEntity.Id ?? throw new ArgumentNullException("Id is null"),
                bookEntity.Title,
                bookEntity.Description,
                bookEntity.Price
                );
        }

        public static List<BookResponse> ToBookResponseList(List<BookEntity> bookEntityList)
        {
            return bookEntityList.Select(b => ToBookResponse(b)).ToList();   
        }

        public static BookEntity ToBookEntity(BookRequest booksRequest)
        {
            return new BookEntity(null, booksRequest.title, booksRequest.description, booksRequest.price);
        }

        public static BookEntity ToBookEntityPartialUpdate(Guid id, BookRequest booksRequest)
        {
            return new BookEntity(id, booksRequest.title, booksRequest.description, booksRequest.price);
        }
    }
}
