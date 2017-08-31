using System.Collections.Generic;

namespace BookStore.Interface
{
    public interface IRepo<T, TKey>
    {
        List<T> GetItems();
        T Get(TKey key);
        void AddItem(T newItem);
        void UpdateItem(TKey key, T updatedItem);
        void DeleteItem(TKey key);
    }
}
