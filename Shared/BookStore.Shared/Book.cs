using System.Collections.Generic;

namespace BookStore.Shared
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Author> Authors { get; set; }

    }
}
