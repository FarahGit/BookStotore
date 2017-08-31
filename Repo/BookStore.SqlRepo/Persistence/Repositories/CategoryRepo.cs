using BookStore.Interface;
using BookStore.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.SqlRepo.Persistence.Repositories
{
    public class CategoryRepo : ICategoryRepo
    {
        private BookContext context = new BookContext();
        public void AddItem(Category newItem)
        {
            throw new NotImplementedException();
        }

        public void DeleteItem(int key)
        {
            throw new NotImplementedException();
        }

        public Category Get(int key)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetItems()
        {
            return context.Categories.ToList();
        }

        public void UpdateItem(int key, Category updatedItem)
        {
            throw new NotImplementedException();
        }
    }
}
