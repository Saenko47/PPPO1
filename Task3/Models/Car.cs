using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using static PaterniLab1.Task3.Tools.Enums;

namespace PaterniLab1.Task3.Models
{
    [PrimaryKey(nameof(Id))]
    internal class Car
    {
        public int Id { get; set; }
        public float MaxWeight { get; set; }

        public LicenceType LincenseNeedsToDrive { get; set; }

        public bool IsUsingRigthNow { get; set; }
    }
}
