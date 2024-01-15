using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Business.Exceptions
{
    public class UserNotFounException:Exception
    {
        public UserNotFounException(string message):base(message)
        {

        }
        public UserNotFounException():base("username ve ya parol duzgun deyil")
        {

        }
    }
}
