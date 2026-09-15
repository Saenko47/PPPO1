using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaterniLab1.Task2.Models.Newspapers
{
    [PrimaryKey(nameof(JournalistId), nameof(NewspaperColumnId))]
    internal class ColumnJournalist
    {
        public int JournalistId { get; set; }
        public int NewspaperColumnId { get; set; }

        public Journalist Journalist { get; set; } = null!;
        public NewspaperColumn NewspaperColumn { get; set; } = null!;

    }
}
