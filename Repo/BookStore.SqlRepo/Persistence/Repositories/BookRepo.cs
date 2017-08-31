using BookStore.Interface;
using BookStore.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.SqlRepo.Persistence.Repositories
{
    public class BookRepo : IBookRepo
    {
        private BookContext context = new BookContext();

        public void AddItem(Book newItem)
        {
            throw new NotImplementedException();
        }

        public void DeleteItem(int key)
        {
            throw new NotImplementedException();
        }

        public Book Get(int key)
        {
            throw new NotImplementedException();
        }

        public List<Book> GetItems()
        {
            return context.Books.ToList();
        }

        public void UpdateItem(int key, Book updatedItem)
        {
            throw new NotImplementedException();
        }
    }
}
