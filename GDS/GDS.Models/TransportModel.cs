using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDS.Models.Enums;

namespace GDS.Models
{
    public class TransportModel : BaseModel
    {
        public string Name { get; set; }

        public string SerialNumber { get; set; }

        public double CargoCapacity { get; set; }

        public TransportState State { get; set; }
    }
}
