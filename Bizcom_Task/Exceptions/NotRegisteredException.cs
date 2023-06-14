using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class NotRegisteredException<T> : Exception
    {
        public NotRegisteredException() : base($"{typeof(T)} is  not registered") { }
    }
}
