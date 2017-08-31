using BookStore.Shared;

namespace BookStore.Interface
{
    public interface IBookRepo : IRepo<Book, int>
    {
    }
}
