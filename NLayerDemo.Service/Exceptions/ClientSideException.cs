using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerDemo.Service.Exceptions
{
    public class ClientSideException:Exception
    {
        public ClientSideException(string message):base(message)
        {

        }
    }
}
