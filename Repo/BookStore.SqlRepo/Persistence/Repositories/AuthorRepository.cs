using BookStore.Interface.Repositories;
using BookStore.Shared;

namespace BookStore.SqlRepo.Persistence.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {

        public AuthorRepository(BookContext context) :
            base(context)
        {

        }
    }
}
