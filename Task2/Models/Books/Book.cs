using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using static PaterniLab1.Task2.Tools.Enums;

namespace PaterniLab1.Task2.Models.Books
{
   
    internal class Book: BaseLibraryItem
    {
       

        public string Author { get; set; } = null!;
        public BookGenre BookGenre { get; set; }
     
        public int AmountOfPages { get; set; }

        public override LibraryItemType LibraryItemType => LibraryItemType.Book;

    }
}
