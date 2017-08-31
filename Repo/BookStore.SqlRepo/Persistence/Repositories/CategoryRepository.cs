using BookStore.Interface.Repositories;
using BookStore.Shared;

namespace BookStore.SqlRepo.Persistence.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(BookContext context)
            :base(context)
        {

        }
    }
}
