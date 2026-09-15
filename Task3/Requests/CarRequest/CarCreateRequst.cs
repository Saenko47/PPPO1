using System;
using System.Collections.Generic;
using System.Text;
using static PaterniLab1.Task3.Tools.Enums;

namespace PaterniLab1.Task3.Requests.CarRequest
{
    internal class CarCreateRequst
    {
        public string Title { get; set; } = null!;
        public float MaxWeight { get; set; }

        public LicenceType LincenseNeedsToDrive { get; set; }
    }
}
