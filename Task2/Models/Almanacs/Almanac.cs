using Microsoft.EntityFrameworkCore;
using PaterniLab1.Task2.Models.Almanacs;
using PaterniLab1.Task2.Tools;
using System;
using System.Collections.Generic;
using System.Text;
using static PaterniLab1.Task2.Tools.Enums;

namespace PaterniLab1.Task2.Models.Amanacs
{
   
    internal class Almanac: BaseLibraryItem
    {
      

        public List<BookAlmanac> BooksInAlmanac = new List<BookAlmanac>();

        public override LibraryItemType LibraryItemType => LibraryItemType.Almanac;
    }
}
