using System;
using System.Collections.Generic;

namespace bookstoreapp.api.Data
{
    public partial class Author
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Biography { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
