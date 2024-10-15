using BookShop.Api.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Api.Configuration
{
    public class BookCongifuration : IEntityTypeConfiguration<BookEntity>
    {
        public void Configure(EntityTypeBuilder<BookEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).HasMaxLength(BookEntity.TITLE_LENGTH_MAX).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(BookEntity.DESCRIPTION_LENGTH_MAX).IsRequired();
            builder.Property(x => x.Price).IsRequired();
        }
    }
}
