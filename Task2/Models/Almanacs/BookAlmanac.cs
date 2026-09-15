using Microsoft.EntityFrameworkCore;
using PaterniLab1.Task2.Models.Amanacs;
using PaterniLab1.Task2.Models.Books;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaterniLab1.Task2.Models.Almanacs
{
    [PrimaryKey(nameof(BookId), nameof(AlmanacId))]
    internal class BookAlmanac
    {
        public int BookId { get; set; }
        public int AlmanacId { get; set; }

        public Book Book { get; set; } = null!;
        public Almanac Almanac { get; set; } = null!;
    }
}
