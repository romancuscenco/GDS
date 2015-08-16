using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDS.Models
{
    public class BaseModel
    {
        public Guid ID { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public Guid UpdatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}
