using BookShop.Api.Models.Entities;

namespace BookShop.Api.Repositories.Interfaces
{
    public interface IBooksRepository
    {
        Task DeleteById(Guid id);
        Task<List<BookEntity>> GetAll();
        Task<BookEntity> GetById(Guid id);
        Task<BookEntity> Save(BookEntity bookEntity);
    }
}