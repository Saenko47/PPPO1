using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaterniLab1.Task2.Models.Newspapers
{
    [PrimaryKey(nameof(Id))]
    internal class NewspaperColumn
    {
        public int Id { get; set; }

        public int NewspaperId { get; set; }

        public string Description { get; set; } = null!;
    }
}
