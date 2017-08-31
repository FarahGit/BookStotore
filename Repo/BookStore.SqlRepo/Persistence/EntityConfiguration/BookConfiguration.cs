using BookStore.Shared;
using System.Data.Entity.ModelConfiguration;

namespace BookStore.SqlRepo.Persistence.EntityConfiguration
{
    public class BookConfiguration : EntityTypeConfiguration<Book>
    {
        public BookConfiguration()
        {
            Property(b => b.Title).IsRequired()
                .HasMaxLength(100);

            Property(b => b.Price).IsRequired();
        }
    }
}
