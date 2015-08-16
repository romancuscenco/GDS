using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDS.Models.Enums;

namespace GDS.Models
{
    public class UserModel : BaseModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public UserRole Role { get; set; }
    }
}
