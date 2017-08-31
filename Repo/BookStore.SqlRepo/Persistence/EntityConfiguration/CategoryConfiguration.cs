using BookStore.Shared;
using System.Data.Entity.ModelConfiguration;

namespace BookStore.SqlRepo.Persistence.EntityConfiguration
{
    public class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            Property(c => c.Name).IsRequired()
                .HasMaxLength(100);   
        }
    }
}
