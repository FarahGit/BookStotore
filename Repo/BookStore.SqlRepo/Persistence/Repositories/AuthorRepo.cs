using BookStore.Interface;
using BookStore.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.SqlRepo.Persistence.Repositories
{
    public class AuthorRepo : IAuthorRepo
    {
        private BookContext context = new BookContext();

        public void AddItem(Author newItem)
        {
            throw new NotImplementedException();
        }

        public void DeleteItem(int key)
        {
            throw new NotImplementedException();
        }

        public Author Get(int key)
        {
            throw new NotImplementedException();
        }

        public List<Author> GetItems()
        {
            return context.Authors.ToList();
        }

        public void UpdateItem(int key, Author updatedItem)
        {
            throw new NotImplementedException();
        }
    }
}
