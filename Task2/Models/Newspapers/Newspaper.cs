using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using static PaterniLab1.Task2.Tools.Enums;

namespace PaterniLab1.Task2.Models.Newspapers
{
 
    internal class Newspaper: BaseLibraryItem
    {
      
        public int NumberOfNewspaper { get; set; }
    

        public List<ColumnJournalist> columnJournalists = new List<ColumnJournalist>();

        public override LibraryItemType LibraryItemType => LibraryItemType.Newspaper;
    }
}
