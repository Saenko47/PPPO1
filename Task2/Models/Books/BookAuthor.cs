using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaterniLab1.Task2.Models.Books
{
    [PrimaryKey(nameof(BookId), nameof(AuthorId))]
    internal class BookAuthor
    {
                public int BookId { get; set; }
                public int AuthorId { get; set; }

                public Book Book { get; set; } = null!;
                public Author Author { get; set; } = null!;
    }
}
