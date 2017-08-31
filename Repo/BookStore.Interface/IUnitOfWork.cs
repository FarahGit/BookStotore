using BookStore.Interface.Repositories;
using System;

namespace BookStore.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IBookRepository Books { get; }
        IAuthorRepository Authors { get; }
        ICategoryRepository Categories { get; }
        int Complete();
    }
}
