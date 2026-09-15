using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaterniLab1.Task2.Models.Newspapers
{
    [PrimaryKey(nameof(Id))]
    internal class Journalist
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public List<ColumnJournalist> ColumsOfThisJournalist = new List<ColumnJournalist>();

    }
}
