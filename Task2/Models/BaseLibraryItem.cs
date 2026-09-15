using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using static PaterniLab1.Task2.Tools.Enums;

namespace PaterniLab1.Task2.Models
{
    [PrimaryKey(nameof(Id))]
    internal abstract class BaseLibraryItem
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public DateTime DateOfPublishing { get; set; }

        public abstract LibraryItemType LibraryItemType { get;}
    }
}
