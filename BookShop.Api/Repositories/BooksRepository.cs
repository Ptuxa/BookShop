using BookShop.Api.DataAccess;
using BookShop.Api.Exceptions;
using BookShop.Api.Models.Entities;
using BookShop.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Api.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private readonly BookShopDbContext _dbContext;

        public BooksRepository(BookShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private async Task<BookEntity> Create(BookEntity bookEntity)
        {
            await _dbContext.AddAsync(bookEntity);
            await _dbContext.SaveChangesAsync();

            return bookEntity;
        }

        private async Task<BookEntity> Update(BookEntity bookEntity)
        {
            var affectedRows = await _dbContext.Books.Where(x => x.Id == bookEntity.Id).
                ExecuteUpdateAsync(x => x.SetProperty(x => x.Title, x => bookEntity.Title)
                    .SetProperty(x => x.Description, x => bookEntity.Description)
                    .SetProperty(x => x.Price, x => bookEntity.Price)
                );

            if (affectedRows <= 0)
            {
                throw new Exception($"Row with id = {bookEntity.Id} was no found");
            }

            return bookEntity;
        }

        public async Task<List<BookEntity>> GetAll()
        {
            List<BookEntity> bookEnitities = await _dbContext.Books.AsNoTracking().
                ToListAsync();

            return bookEnitities;
        }

        public async Task<BookEntity> GetById(Guid id)
        {
            BookEntity? bookEntity = await _dbContext.Books.FindAsync(id);

            if (bookEntity != null)
            {
                return bookEntity;
            }

            throw new NotFoundDbException($"Book with id = {id} was not found");
        }

        public async Task<BookEntity> Save(BookEntity bookEntity)
        {
            if (bookEntity.Id == null)
            {
                bookEntity.Id = Guid.NewGuid();
                return await Create(bookEntity);                
            }
            else
            {
                return await Update(bookEntity);
            }            
        }

        public async Task DeleteById(Guid id)
        {
            await _dbContext.Books
                .Where(b => b.Id == id)
                .ExecuteDeleteAsync();
        }
    }
}
