using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Entities.ModelView
{
    public class UserAuthInfo
    {
        public UserDTO UserCredentials { get; set; }
        public string Token { get; set; }
    }
}
