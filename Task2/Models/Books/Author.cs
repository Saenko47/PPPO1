using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaterniLab1.Task2.Models.Books
{
    [PrimaryKey(nameof(Id))]
    internal class Author
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public List<BookAuthor> BooksOfAuthor = new List<BookAuthor>();

    }
}
