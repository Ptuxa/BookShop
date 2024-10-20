using BookShop.Api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Api.DataAccess
{
    public class BookShopDbContext : DbContext
    {
        public BookShopDbContext(DbContextOptions<BookShopDbContext> options) : base(options) 
        {

        }
            
        public DbSet<BookEntity> Books { get; set; }
    }
}
