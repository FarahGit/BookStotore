using BookStore.Shared;
using BookStore.SqlRepo.Persistence.EntityConfiguration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BookStore.SqlRepo.Persistence
{
    public class BookContext : DbContext
    {
        public BookContext() : base("BookCatalog")
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BookConfiguration());
            modelBuilder.Configurations.Add(new AuthorConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
