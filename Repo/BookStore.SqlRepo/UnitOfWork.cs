using BookStore.Interface;
using BookStore.Interface.Repositories;
using BookStore.SqlRepo.Persistence;
using BookStore.SqlRepo.Persistence.Repositories;

namespace BookStore.SqlRepo
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookContext context;

        public UnitOfWork(BookContext context)
        {
            this.context = context;

            Books = new BookRepository(this.context);
            Authors = new AuthorRepository(this.context);
            Categories = new CategoryRepository(this.context);

        }
        public IAuthorRepository Authors { get; private set; }
        public IBookRepository Books { get; private set; }
        public ICategoryRepository Categories { get; private set; }

        public int Complete()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
