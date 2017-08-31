using BookStore.Interface.Repositories;
using BookStore.Shared;

namespace BookStore.SqlRepo.Persistence.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(BookContext context)
            : base(context)
        {

        }
    }
}
