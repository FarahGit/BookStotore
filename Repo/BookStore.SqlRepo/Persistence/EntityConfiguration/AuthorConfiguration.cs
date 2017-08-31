using BookStore.Shared;
using System.Data.Entity.ModelConfiguration;

namespace BookStore.SqlRepo.Persistence.EntityConfiguration
{
    public class AuthorConfiguration : EntityTypeConfiguration<Author>
    {
        public AuthorConfiguration()
        {
            Property(a => a.Name).IsRequired()
                .HasMaxLength(50);
        }
    }
}
