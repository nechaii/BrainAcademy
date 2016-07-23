using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayException
{
    class UserExceptionA :Exception
    {
        public UserExceptionA(string message) : base(message)
        {

        }
    }

    class UserExceptionB : UserExceptionA
    {
        public UserExceptionB(string message) : base(message)
        {

        }
    }
}
